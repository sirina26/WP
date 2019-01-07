import { getAsync, postAsync, putAsync, deleteAsync } from '../helpers/apiHelper'

const endpoint = process.env.VUE_APP_BACKEND + "/api/user";


export async function getUserIdAsync() {
    return await getAsync(`${endpoint}/GetUserId`);
}