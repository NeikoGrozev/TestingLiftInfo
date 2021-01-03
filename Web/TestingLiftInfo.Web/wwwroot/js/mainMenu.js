let headerSection = document.querySelector('header section');
let navigation = document.querySelector('header nav.o-row-container');
let navigationMobileElement = document.querySelector('header .o-mobile-nav');

let toggleElement = document.querySelector('#toggle');

(function test() {
    if (window.screen.width <= 900) {

        toggleElement.style.display = 'block'
    } else {
        navigation.style.display = 'flex';
    }
})()

window.addEventListener('resize', resizeScreen);

function resizeScreen(e) {
    if (window.screen.width <= 900) {
        navigation.remove();
        headerSection.appendChild(toggleElement);
        toggleElement.style.display = 'block';
    } else {
        toggleElement.remove();
        headerSection.appendChild(navigation);
        navigation.style.display = 'flex';
        navigationMobileElement.style.display = 'none';
        toggleElement.classList.remove('on');
    }
}
