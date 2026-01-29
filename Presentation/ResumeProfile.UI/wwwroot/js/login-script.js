document.addEventListener('DOMContentLoaded', () => {
    const loginForm = document.getElementById('login-form');
    const usernameInput = document.getElementById('username');
    const passwordInput = document.getElementById('password');

    // 1. Form Submission Handler
    loginForm.addEventListener('submit', (e) => {
        e.preventDefault();

        const username = usernameInput.value.trim();
        const password = passwordInput.value;

        // Simple client-side validation
        if (username === "" || password === "") {
            alert("لطفاً نام کاربری/ایمیل و رمز عبور را وارد کنید.");
            return;
        }

        // 2. Simulation of Login Process
        // In a real application, an API call (fetch/axios) would be made here.
        
        // Example credentials for simulation:
        if (username === "admin" && password === "123456") {
            // Success: Redirect to the admin panel
            alert("ورود موفقیت‌آمیز. در حال انتقال به پنل ادمین...");
            // window.location.href = 'admin.html'; // Uncomment for actual redirection
        } else if (username === "admin@test.com" && password === "123456") {
            // Success with email login
            alert("ورود موفقیت‌آمیز. در حال انتقال به پنل ادمین...");
            // window.location.href = 'admin.html'; // Uncomment for actual redirection
        } else {
            // Failure
            alert("نام کاربری یا رمز عبور اشتباه است.");
            // Clear password field on failure
            passwordInput.value = '';
        }
    });
    
    // 3. Forgot Password Link Handler (Simulation)
    const forgotPasswordLink = document.querySelector('.forgot-password');
    forgotPasswordLink.addEventListener('click', (e) => {
        e.preventDefault();
        alert("صفحه بازیابی رمز عبور هنوز پیاده‌سازی نشده است. لطفاً با پشتیبانی تماس بگیرید.");
        // In a real app, this would redirect to a password reset page
    });
});