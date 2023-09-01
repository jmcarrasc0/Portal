using MimeKit;

namespace Jmcarrasc0.Portal.Services
{
    public class Mensajeria
    {
        private readonly IConfiguration conf;

        public Mensajeria(IConfiguration _conf)
        {

            conf = _conf;

        }


        private bool EnviarCorreo(string Cuerpo, List<Addressee> ad, List<Addressee>? adc, List<Addressee>? adbc, List<Attached>? at, string subject)
        {
            var mail = new Mail();

            var email = new Email()
            {
                IsSSL = Convert.ToBoolean(conf["MailService:EnableSSL"]),
                Body = Cuerpo,
                BodyIsHtml = Convert.ToBoolean(conf["MailService:HTMLbody"]),
                Addressees = ad,
                AddresseesCC = adc,
                AddresseesBCC = adbc,
                ScreenName = conf["MailService:NombrePantalla"],
                Port = Convert.ToInt32(conf["MailService:PuertoCorreo"]),
                Title = subject,
                Account = conf["MailService:correo"],
                Password = conf["MailService:Pass"],
                MailServer = conf["MailService:Hostmail"],
                Attachments = at

            };
            return mail.SendMail(email);
        }

        public bool EnviarCorreoBienvenida(string Nombre, string Apellido, string UserName, string Correo, string IDUser)
        {

            var ListPara = new List<Addressee>
                {new Addressee {ShowName = $"{Nombre} {Apellido}", Mail= Correo}};
            var rp = File.ReadAllText($"./Formats/Welcome.html");
            rp = rp.Replace("$Nombre$", $"{Nombre} {Apellido}")
                .Replace("$UserName$", $"{UserName}")
             .Replace("$Link$", @$"{conf["Enviroment:Url"]}Autenticar/{IDUser}"); ;



            return EnviarCorreo(rp, ListPara, new List<Addressee>(), new List<Addressee>(), new List<Attached>(), "Registro exitoso Portal Winledger");


        }

        public bool EnviarCorreoReinicioContraseña(string Nombre, string Apellido, string UserName, string Correo, string ID)
        {

            var ListPara = new List<Addressee>
                {new Addressee {ShowName = $"{Nombre} {Apellido}", Mail = Correo}};
            var rp = File.ReadAllText($"./Formatos/ReiniciarContraseña.html");
            rp = rp.Replace("$Nombre$", $"{Nombre} {Apellido}")
                .Replace("$UserName$", $"{UserName}")
                .Replace("$Link$", @$"{conf["Enviroment:Url"]}ReiniciarContraseña/{ID}");



            return EnviarCorreo(rp, ListPara, new List<Addressee>(), new List<Addressee>(), new List<Attached>(), "Reiniciar tu Contraseña");


        }


        public bool EnviarCorreoAuntenticacion(string Nombre, string Apellido, string UserName, string Correo)
        {

            var ListPara = new List<Addressee>
                {new Addressee {ShowName = $"{Nombre} {Apellido}", Mail = Correo}};
            var rp = File.ReadAllText($"./Formatos/Autenticacion.html");
            rp = rp.Replace("$Nombre$", $"{Nombre} {Apellido}")
                .Replace("$UserName$", $"{UserName}");



            return EnviarCorreo(rp, ListPara, new List<Addressee>(), new List<Addressee>(), new List<Attached>(), "Autenticación Correcta");


        }



    }


    public class Attached
    {
        public byte[] file { get; set; }
        public string name { get; set; }
        public string MediaType { get; set; }

    }

    public class Addressee
    {
        public string ShowName { get; set; }
        public string Mail { get; set; }
    }

    public interface IEmail
    {
        List<Addressee> Addressees { get; set; }
        List<Addressee> AddresseesCC { get; set; }
        List<Addressee> AddresseesBCC { get; set; }
        string Title { get; set; }
        string Body { get; set; }
        string ScreenName { get; set; }
        int Port { get; set; }
        bool IsSSL { get; set; }
        bool BodyIsHtml { get; set; }
        List<Attached> Attachments { get; set; }
    }


    public class Email : IEmail
    {
        public List<Addressee> Addressees { get; set; }
        public List<Addressee> AddresseesCC { get; set; }
        public List<Addressee> AddresseesBCC { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string ScreenName { get; set; }
        public int Port { get; set; }
        public bool IsSSL { get; set; }
        public bool BodyIsHtml { get; set; }
        public List<Attached> Attachments { get; set; }
        public string MailServer { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }

    }

    public class EmailHost : IEmail
    {
        public string Host { get; set; }
        public List<Addressee> Addressees { get; set; }
        public List<Addressee> AddresseesCC { get; set; }
        public List<Addressee> AddresseesBCC { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string From { get; set; }
        public string ScreenName { get; set; }
        public int Port { get; set; }
        public bool IsSSL { get; set; }
        public bool BodyIsHtml { get; set; }
        public List<Attached> Attachments { get; set; }


    }

    public class Mail
    {
        public bool SendMail(Email mail)
        {

            try
            {

                var email = new MimeMessage();

                email.From.Add(new MailboxAddress($"{mail.ScreenName}", $"{mail.Account}"));
                email.Subject = mail.Title;
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = $"{mail.Body}"
                };

                foreach (var to in mail.Addressees)
                {
                    email.To.Add(new MailboxAddress($"{to.ShowName}", $"{to.Mail}"));
                }

                if (mail.AddresseesCC != null)
                {
                    foreach (var cc in mail.AddresseesCC)
                    {
                        email.Cc.Add(new MailboxAddress(cc.Mail, cc.ShowName));
                    }
                }

                if (mail.AddresseesBCC != null)
                {

                    foreach (var bcc in mail.AddresseesBCC)
                    {
                        email.Bcc.Add(new MailboxAddress(bcc.Mail, bcc.ShowName));
                    }

                }


                using (var smtp = new MailKit.Net.Smtp.SmtpClient())
                {
                    smtp.Connect(mail.MailServer, mail.Port, mail.IsSSL);

                    // Note: only needed if the SMTP server requires authentication
                    smtp.Authenticate(mail.Account, mail.Password);

                    smtp.Send(email);
                    return true;
                    smtp.Disconnect(true);


                }


            }
            catch (Exception ex)
            {

                var argEx = new ArgumentException("A problem occurred while sending mail", ex);
                throw argEx;
            }

        }



    }


    public class Bienvenida
    {

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string UserName { get; set; }
        public string Correo { get; set; }
        public string Formato { get; set; }
        public string Link { get; set; }
        public string Titulo { get; set; }
    }

    public class ReinicioContraseña
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string UserName { get; set; }
        public string Correo { get; set; }
        public string Link { get; set; }
        public string Titulo { get; set; }
        public string Formato { get; set; }

    }

    public class Generico
    {
        public string Formato { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Titulo { get; set; }
        public string Generico0 { get; set; }
        public string? Generico1 { get; set; }
        public string? Generico2 { get; set; }
        public string? Generico3 { get; set; }
        public string? Generico4 { get; set; }
        public string? Generico5 { get; set; }
        public string? Generico6 { get; set; }
        public string? Generico7 { get; set; }
        public string? Generico8 { get; set; }
        public string? Generico9 { get; set; }
        public string? Generico10 { get; set; }
        public string? Generico11 { get; set; }
        public string? Generico12 { get; set; }
        public string? Generico13 { get; set; }
        public string? Generico14 { get; set; }
        public string? Generico15 { get; set; }
        public string? Generico16 { get; set; }
        public string? Generico17 { get; set; }
        public string? Generico18 { get; set; }
        public string? Generico19 { get; set; }
        public string? Generico20 { get; set; }

    }
}
