function submitPoll() {
    const question1 = document.getElementsByName('question1');
    const question2 = document.getElementsByName('question2');        
    let answer1, answer2;

    for (const option of question1) {
        if (option.checked) {
            answer1 = option.value;
            break;
        }
    }

    for (const option of question2) {
        if (option.checked) {
            answer2 = option.value;
            break;
        }
    }

    // Check answers and redirect to a new page
    if (answer1 && answer2) { 
        console.log('Both options have been selected.');
        if (answer1 === 'option1' && answer2 === 'yes') {
            // Redirect to newpage.html
            window.location.href = "thnku.html";
        } else {
            alert("Unfortunately, your response was not accepted.");
        }
    } else {
        alert("Please select your options.");
    }
}