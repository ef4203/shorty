function createShortHand() {
    var data = document.getElementById('urlinput').value;

    if (!data || data === "") return;

    var request = new XMLHttpRequest();
    request.open('POST', '/s', true);
    request.setRequestHeader('Content-Type', 'application/json');
    request.send(JSON.stringify({
        destination: data
    }));

    request.onreadystatechange = () => {
        var p = document.getElementById('result');
        p.innerHTML = `${request.responseURL}/${request.response}`;
    };
}
