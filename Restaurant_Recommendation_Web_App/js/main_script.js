function handleRedirect() {

    const selectedOptions = [];

    for (let i = 1; i <= 4; i++) {

        const selectedOption =
            document.querySelector(`input[name=question${i}]:checked`);

        if (selectedOption) {
            selectedOptions.push(selectedOption.value);
        } else {
            selectedOptions.push(null);
        }
    }

    const queryString =
        selectedOptions
        .map((option, index) =>
            `question${index + 1}=${option}`)
        .join('&');

    // Redirect Logic
    if (selectedOptions[3] === "option1") {
        window.location.href =
            `newpage1.html?${queryString}`;
    }

    else if (selectedOptions[3] === "option2") {
        window.location.href =
            `newpage2.html?${queryString}`;
    }
}


window.onload = function() {

    const elements =
        document.querySelectorAll('.fade-in');

    elements.forEach((element) => {
        element.classList.add('visible');
    });

};
