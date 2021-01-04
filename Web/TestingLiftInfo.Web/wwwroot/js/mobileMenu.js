let toggle = document.querySelector('#toggle');

toggle.addEventListener('click', clickToggle);

function clickToggle(e) {

    let allValues = e.currentTarget.getAttribute('class');

    if (allValues.includes('on')) {
        e.currentTarget.classList.remove('on');
        hideMobileMenu();
    } else {
        e.currentTarget.classList.add("on");
        unhideMobileMenu();

    }
}

let mainSection = document.querySelector('.o-main-container');
mainSection.addEventListener('click', closeToggle);

function closeToggle(e) {
    if (toggle.getAttribute('class').includes('on')) {
        toggle.classList.remove('on');
        hideMobileMenu();
    }
};

let navigationMobile = document.querySelector('header .o-mobile-nav');
let mobileLifts = document.querySelector('#mobileLifts');
let mobileLiftsHiden = document.querySelectorAll('#mobileLiftsHiden');
let mobileAdministration = document.querySelector('#mobileAdministration');
let mobileAdministrationHiden = document.querySelectorAll('#mobileAdministrationHiden');

function unhideMobileMenu() {
    navigationMobile.style.display = 'block';
}

function hideMobileMenu() {
    navigationMobile.style.display = 'none';

    if (mobileLiftsHiden[0].style.display == 'flex') {
        mobileLiftsHiden.forEach(x => x.style.display = 'none');
    }

    if (mobileAdministrationHiden[0].style.display == 'flex') {
        mobileAdministrationHiden.forEach(x => x.style.display = 'none');
    }
}

mobileLifts.addEventListener('click', hidenLiftsMenu)

function hidenLiftsMenu(e) {

    if (mobileLiftsHiden[0].style.display != 'flex') {
        mobileLiftsHiden.forEach(x => x.style.display = 'flex');
    } else {
        mobileLiftsHiden.forEach(x => x.style.display = 'none');
    }
}

mobileAdministration.addEventListener('click', hidenAdministrationMenu)

function hidenAdministrationMenu(e) {

    if (mobileAdministrationHiden[0].style.display != 'flex') {
        mobileAdministrationHiden.forEach(x => x.style.display = 'flex');
    } else {
        mobileAdministrationHiden.forEach(x => x.style.display = 'none');
    }
}