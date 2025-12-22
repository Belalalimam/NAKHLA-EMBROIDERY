const menuTrigger = document.querySelector('.trigger');
const closeTrigger = document.querySelector('.mini-close');
const giveClass = document.querySelector('.site');

menuTrigger.addEventListener('click', function () {
    giveClass.classList.add('showmenu');
});

closeTrigger.addEventListener('click', function () {
    giveClass.classList.remove('showmenu');
});



//submenu
const button = document.querySelectorAll('.has-child > a'),
    modalheight = document.querySelector('.menu-list');

button.forEach((item) => item.parentNode.classList.remove('expand'));
button.forEach((menu) => menu.addEventListener('click', function () {
    let modal = document.querySelector('.menu-list');
    modal.classList.toggle('show');

    if (this.parentNode.classList != 'expand') {
        this.parentNode.classList.toggle('expand')
    }
    if (!modal.classList.contains('show')) {
        modal.style.height = modalheight + 'px';
    } else {
        modal.style.height = (this.parentNode.querySelector('ul').offsetHeight + 45) + 'px';
    }

    //back button

    menu.parentNode.querySelector('.back').addEventListener('click', function () {
        modal.style.height = 'auto';
        modal.classList.remove('show');
        menu.parentNode.classList.remove('expand')
    })
}))

const topmenu = document.querySelectorAll('.top li a ');
for (let i = 0; i < topmenu.length; i++) {
    topmenu[i].addEventListener('click', function () {

        let current = document.querySelectorAll('.active');

        //remove active class
        if (this.classList.contains('active')) {
            this.classList.remove('active');
            document.querySelector(`#${this.classList}`).classList.remove('active')
            return;
        }

        //if there's no active class
        if (current.length > 0) {
            current[0].classList.remove('active');
            document.querySelector(`#${current[0].className}`).classList.remove('active');
        }

        //add active to id 
        document.querySelector(`#${this.className}`).classList.add('active');

        //add active class to the current/clicked button
        this.classList.add('active');

    })
}