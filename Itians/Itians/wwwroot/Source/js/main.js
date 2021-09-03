function showDiv() {
    [].forEach.call(document.querySelectorAll('[name=inlineRadioOptions]'), function(button) {
        document.getElementById(button.dataset.divid).className = button.checked ? '' : 'hidden';
    })
}

// Attach click listeners onload
window.onload = function () {
    document.getElementById('company').className = 'hidden';
    [].forEach.call(document.querySelectorAll('[name=inlineRadioOptions]'), function(button) {
        button.onclick = showDiv;
    })
}