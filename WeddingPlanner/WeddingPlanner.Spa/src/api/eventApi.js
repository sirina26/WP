import { getAsync, postAsync, putAsync, deleteAsync } from '../helpers/apiHelper'

const endpoint = process.env.VUE_APP_BACKEND + "/api/event";

export async function getEventListAsync() {
    return await getAsync(endpoint);
}

export async function getIdAsync(email) {
    return await getAsync(`${endpoint}/${email}`);
}

export async function getEventAsync(eventId) {
    return await getAsync(`${endpoint}/${eventId}`);
}

export async function createEventAsync(model) {
    return await postAsync(endpoint, model);
}

export async function updateEventAsync(model) {
    return await putAsync(`${endpoint}/${model.eventId}`, model);
}

export async function deleteEventAsync(eventId) {
    return await deleteAsync(`${endpoint}/${eventId}`);
}

