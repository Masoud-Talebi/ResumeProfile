window.adminPanelScripts = {
    init: function () {
        // 1. Sidebar Navigation Logic
        const navItems = document.querySelectorAll('.nav-item');
        const contentSections = document.querySelectorAll('.content-section');

        navItems.forEach(item => {
            item.addEventListener('click', (e) => {
                e.preventDefault();

                // Remove active class from all items and sections
                navItems.forEach(i => i.classList.remove('active'));
                contentSections.forEach(s => s.classList.remove('active'));

                // Add active class to clicked item
                item.classList.add('active');

                // Show corresponding section
                const targetId = item.getAttribute('href').substring(1);
                const targetSection = document.getElementById(targetId);
                if (targetSection) targetSection.classList.add('active');
            });
        });

        // 2. Stat Card Counter Animation
        const counters = document.querySelectorAll('.card-value');
        const speed = 200;
        counters.forEach(counter => {
            const updateCount = () => {
                const target = +counter.getAttribute('data-target');
                const count = +counter.innerText;
                const inc = target / speed;
                if (count < target) {
                    counter.innerText = Math.ceil(count + inc);
                    setTimeout(updateCount, 1);
                } else counter.innerText = target;
            };
            setTimeout(updateCount, 500);
        });

        // 3. Project Form Submission
        const addProjectForm = document.getElementById('add-project-form');
        const projectsTableBody = document.querySelector('#projects-table tbody');

        if (addProjectForm && projectsTableBody) {
            addProjectForm.addEventListener('submit', (e) => {
                e.preventDefault();
                const title = document.getElementById('project-title').value;
                const description = document.getElementById('project-description').value;
                const imageLink = document.getElementById('project-image-link').value;

                if (!title || !description || !imageLink) {
                    alert("لطفاً همه فیلدها را پر کنید.");
                    return;
                }

                const newId = projectsTableBody.children.length + 1;
                const currentDate = new Date().toLocaleDateString('fa-IR', { year: 'numeric', month: '2-digit', day: '2-digit' });

                const newRow = `
                    <tr data-id="${newId}" class="fade-in-row">
                        <td>${title}</td>
                        <td>${currentDate}</td>
                        <td><span class="status-badge pending">در حال انجام</span></td>
                        <td><img src="${imageLink}" alt="تصویر پروژه" class="project-thumb"></td>
                        <td>
                            <button class="action-btn edit-btn"><i class="fas fa-edit"></i></button>
                            <button class="action-btn delete-btn"><i class="fas fa-trash-alt"></i></button>
                        </td>
                    </tr>
                `;
                projectsTableBody.insertAdjacentHTML('beforeend', newRow);
                addProjectForm.reset();

                const addedRow = projectsTableBody.lastElementChild;
                addedRow.style.animation = 'fade-in 0.5s ease-out';

                alert(`پروژه "${title}" با موفقیت اضافه شد.`);
            });

            // Delete Button
            projectsTableBody.addEventListener('click', (e) => {
                if (e.target.closest('.delete-btn')) {
                    const row = e.target.closest('tr');
                    const projectId = row.getAttribute('data-id');
                    const projectName = row.querySelector('td:first-child').innerText;

                    if (confirm(`آیا مطمئنید که می‌خواهید پروژه "${projectName}" را حذف کنید؟`)) {
                        row.style.opacity = '0';
                        row.style.transition = 'opacity 0.5s ease-out';
                        setTimeout(() => {
                            row.remove();
                            alert(`پروژه با ID ${projectId} حذف شد.`);
                        }, 500);
                    }
                }
            });
        }

        // 4. Logout Button
        const logoutBtn = document.getElementById('logout-btn');
        if (logoutBtn) {
            logoutBtn.addEventListener('click', () => {
                if (confirm('آیا می‌خواهید از پنل خارج شوید؟')) {
                    alert('خروج انجام شد.');
                    window.location.replace("/");
                }
            });
        }
    }
};






// اضافه کردن مدرک جدید به جدول
const certificateForm = document.getElementById('add-certificate-form');
const certificatesTable = document.getElementById('certificates-table').querySelector('tbody');

certificateForm.addEventListener('submit', function (e) {
    e.preventDefault();

    const title = document.getElementById('certificate-title').value;
    const desc = document.getElementById('certificate-description').value;
    const org = document.getElementById('certificate-org').value;
    const year = document.getElementById('certificate-year').value;

    const newRow = document.createElement('tr');
    const newId = certificatesTable.querySelectorAll('tr').length + 1;

    newRow.setAttribute('data-id', newId);
    newRow.innerHTML = `
        <td>${title}</td>
        <td>${desc}</td>
        <td>${org}</td>
        <td>${year}</td>
        <td>
            <button class="action-btn edit-btn"><i class="fas fa-edit"></i></button>
            <button class="action-btn delete-btn"><i class="fas fa-trash-alt"></i></button>
        </td>
    `;
    certificatesTable.appendChild(newRow);

    certificateForm.reset();
});

