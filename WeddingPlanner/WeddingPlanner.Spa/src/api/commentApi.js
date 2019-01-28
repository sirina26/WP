import { getAsync, postAsync, putAsync, deleteAsync } from '../helpers/apiHelper'

const endpoint = process.env.VUE_APP_BACKEND + "/api/comment";

export async function getCommentAsync(commentId){
    return await getAsync(`${endpoint}/${commentId}`);
}

export async function getCommentListAsync() {
    return await getAsync(endpoint);
}

export async function createCommentAsync(model){
    return await postAsync(endpoint, model);
}

export async function updateCommentAsync(model){
    return await putAsync(`${endpoint}/${model.commentId}`, model);
}

export async function deleteCommentAsync(commentId){
    return await deleteAsync(`${endpoint}/${commentId}`);
}