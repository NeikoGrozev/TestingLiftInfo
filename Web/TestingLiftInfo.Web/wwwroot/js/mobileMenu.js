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

let navigationMobile = document.querySelector('header .o-mobile-nav');

function unhideMobileMenu() {
    navigationMobile.style.display = 'block';
}

function hideMobileMenu() {
    navigationMobile.style.display = 'none';
}

let mobileLifts = document.querySelector('#mobileLifts');
let mobileLiftsHiden = document.querySelectorAll('#mobileLiftsHiden');
mobileLifts.addEventListener('click', hidenLiftsMenu)

function hidenLiftsMenu(e) {

    if (mobileLiftsHiden[0].style.display != 'flex') {
        mobileLiftsHiden.forEach(x => x.style.display = 'flex');
    } else {
        mobileLiftsHiden.forEach(x => x.style.display = 'none');
    }
}

let mobileAdministration = document.querySelector('#mobileAdministration');
let mobileAdministrationHiden = document.querySelectorAll('#mobileAdministrationHiden');
mobileAdministration.addEventListener('click', hidenAdministrationMenu)

function hidenAdministrationMenu(e) {

    if (mobileAdministrationHiden[0].style.display != 'flex') {
        mobileAdministrationHiden.forEach(x => x.style.display = 'flex');
    } else {
        mobileAdministrationHiden.forEach(x => x.style.display = 'none');
    }
}