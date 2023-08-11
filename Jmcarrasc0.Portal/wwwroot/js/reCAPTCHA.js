function onClick(e) {
    e.preventDefault();
    grecaptcha.enterprise.ready(async () => {
        const token = await grecaptcha.enterprise.execute('6LflDoknAAAAAHxLtYE433xP9aPyBxxjG1cs23V_', { action: 'LOGIN' });
        // IMPORTANT: The 'token' that results from execute is an encrypted response sent by
        // reCAPTCHA Enterprise to the end user's browser.
        // This token must be validated by creating an assessment.
        // See https://cloud.google.com/recaptcha-enterprise/docs/create-assessment
    });
}