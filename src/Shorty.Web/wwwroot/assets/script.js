async function createShortHand() 
{
    let data = document.getElementById('url-input').value;

    if (!data || data === "") 
        return;
    
    let result = await fetch('/api/shorthands', { 
        method: 'POST', 
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ destination: data })
    });

    if (result.ok){
        document.getElementById('result').innerHTML = 
            `${window.location.origin}/s/${await result.text()}`;
    }
}

async function deleteShortHand(id) 
{
   if (!id || id === "") 
       return;
   
   let result = await fetch(`/api/shorthands/${id}`, { method: 'DELETE' });
   window.location.reload();
}
