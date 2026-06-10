window.onload = function () {
    
    // fade-in animation
    const elements = document.querySelectorAll('.fade-in');
    elements.forEach((element) => {
        element.classList.add('visible');
    });
};

// Back button function
function goBack() {
    if (document.referrer && document.referrer !== "") {
        window.location.href = document.referrer;
    } else {
        window.location.href = "main.html";
    }
}