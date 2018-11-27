import { getAsync, postAsync, putAsync, deleteAsync } from '../helpers/apiHelper'

const endpoint = process.env.VUE_APP_BACKEND + "/api/event";

export async function getMailListAsync() {
    return await getAsync(endpoint);
}

export async function getMailAsync(eventId) {
    return await getAsync(`${endpoint}/${eventId}`);
}

export async function createMailAsync(model) {
    console.log(endpoint);
    return await postAsync(endpoint, model);
}

export async function updateMailAsync(model) {
    return await putAsync(`${endpoint}/${model.eventId}`, model);
}

export async function deleteMailAsync(eventId) {
    return await deleteAsync(`${endpoint}/${eventId}`);
}