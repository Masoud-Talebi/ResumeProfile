window.siteScripts = {
    init: function () {
        // کل کد داخل DOMContentLoaded را اینجا بگذار
        const animateElements = document.querySelectorAll('.fade-in, .slide-up');
        const observerOptions = { root: null, rootMargin: '0px', threshold: 0.1 };

        const observer = new IntersectionObserver((entries, observer) => {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    const element = entry.target;
                    const delay = element.getAttribute('data-delay') || 0;
                    console.warn('sssss')
                    setTimeout(() => {
                        element.classList.add('animated');
                        if (element.id === 'skills') animateProgressBars();
                    }, parseFloat(delay) * 1000);

                    observer.unobserve(element);
                }
            });
        }, observerOptions);

        animateElements.forEach(el => observer.observe(el));

        function animateProgressBars() {
            const progressBars = document.querySelectorAll('.progress-bar');
            progressBars.forEach(bar => {
                const level = bar.getAttribute('data-level');
                bar.style.width = `${level}%`;
            });
        }

        // Contact Form
        const contactForm = document.getElementById('contact-form');
        const formMessage = document.getElementById('form-message');

        if (contactForm) {
            contactForm.addEventListener('submit', function (e) {
                e.preventDefault();
                const name = document.getElementById('name').value.trim();
                const email = document.getElementById('email').value.trim();
                const message = document.getElementById('message').value.trim();

                if (name && email && message) {
                    formMessage.textContent = 'پیام شما با موفقیت ارسال شد. از شما متشکریم!';
                    formMessage.style.color = 'var(--color-accent)';
                    this.reset();
                } else {
                    formMessage.textContent = 'لطفاً همه فیلدها را پر کنید.';
                    formMessage.style.color = 'red';
                }
                formMessage.focus();
            });
        }
    }
};
