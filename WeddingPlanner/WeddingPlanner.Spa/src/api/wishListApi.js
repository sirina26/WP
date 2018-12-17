import { getAsync, postAsync, putAsync, deleteAsync } from '../helpers/apiHelper'

const endpoint = process.env.VUE_APP_BACKEND + "/api/wishListe";

export async function getWishListAsync() {
    return await getAsync(endpoint);
}

export async function getWishAsync(taskId) {
    return await getAsync(`${endpoint}/${taskId}`);
}

export async function createTaskAsync(model) {
    return await postAsync(endpoint, model);
}

export async function updateWishListAsync(model) {
    return await putAsync(`${endpoint}/${model.taskId}`, model);
}

export async function deleteWishListAsync(taskId) {
    return await deleteAsync(`${endpoint}/${taskId}`);
}