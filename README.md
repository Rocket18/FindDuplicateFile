# FindDuplicateFile
СЕРЕДОВИЩЕ
Програма повинна бути створена використовуючи C#.Net і розрахована на роботу у середовищі однієї із сучасних версій Windows. Повинна досягатися прийнятна продуктивність при роботі з структурами каталогів із кількома сотнями тисяч файлів. При розробці потрібно виходити із припущення, що розмір файлів не перевищує 2 гігабайт і глибина структури каталогів не перевищує лімітів операційної системи для доступуп до файлу по повному шляху. 
ЗАДАЧА
Знайти всі групи однакових файлів ненульової довжини у заданому каталозі та його підкаталогах. 
Однаковими файлами вважаються такі файли, у яких співпадає вміст. Додаткові атрибути файлів, права доступу, альтернативні потоки даних, чи будь-які інші особливості конкретних реалізацій файлових систем на порівняння не впливають.  
Програма повинна вивести повні шляхи до знайдених файлів  у межах кожної групи. Групи повинні відділятися однією порожньою стрічкою. Каталог, у межах якого потрібно здійснювати пошук, повинен задаватися у командній стрічці програми.
Помилки доступу чи читання файлів необхідно ігнорувати, а відповідні файли ¬– виключати із розгляду.
