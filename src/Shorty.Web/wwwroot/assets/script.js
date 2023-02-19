function createShortHand() {
    var data = document.getElementById('url-input').value;

    if (!data || data === "") return;

    var request = new XMLHttpRequest();
    request.open('POST', '/api/shorthands', true);
    request.setRequestHeader('Content-Type', 'application/json');
    request.send(JSON.stringify({
        destination: data
    }));

    request.onreadystatechange = () => {
        var p = document.getElementById('result');
        p.innerHTML = `${window.location.origin}/s/${request.response}`;
    };
}
