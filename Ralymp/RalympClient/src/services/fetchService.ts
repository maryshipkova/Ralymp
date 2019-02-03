const baseUrl = 'https://ralymp.azurewebsites.net/api';


export function get(url:string) {
    const params: Object = {
        method: 'GET',
        mode: 'cors',
        headers: {
            'Access-Control-Allow-Origin': '*'
        }
    };
    return fetch(`${baseUrl}/${url}`, params)
        .then((resp) => resp.json());
}

