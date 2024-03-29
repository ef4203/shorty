async function createShortHand() {
    let uri = document.getElementById('url-input').value;
    let validity = parseInt(document.getElementById('validity-input').value, 10);

    if (!uri || uri === "")
        return;

    let result = await fetch('/api/shorthands', {
        method: 'POST',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify({destination: uri, expiresInDays: validity})
    });

    if (result.ok) {
        document.getElementById('result').innerHTML =
            `${window.location.origin}/s/${await result.text()}`;
    }
}

async function deleteShortHand(id) {
    if (!id || id === "")
        return;

    let result = await fetch(`/api/shorthands/${id}`, {method: 'DELETE'});
    window.location.reload();
}
