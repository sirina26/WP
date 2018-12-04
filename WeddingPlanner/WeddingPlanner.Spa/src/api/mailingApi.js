import { getAsync, postAsync, putAsync, deleteAsync } from '../helpers/apiHelper'

const endpoint = process.env.VUE_APP_BACKEND + "/api/mailing";

//si j'eregistre dans bdd   
export async function getMailListAsync() {
    return await getAsync(endpoint);
}
export async function getMailAsync(emailId) {
    return await getAsync(endpoint);
}

export async function createMailAsync(model) {
    console.log(endpoint);
    return await postAsync(endpoint, model);
}
