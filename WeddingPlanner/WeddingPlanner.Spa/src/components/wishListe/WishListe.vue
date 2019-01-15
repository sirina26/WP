<template>
    <div>
        <div class="mb-4 d-flex justify-content-between">
            <h1>Gestion des tâches </h1>

            <div>
                <router-link class="btn btn-primary" :to="`wishListe/create`"><i class="fa fa-plus"></i> Ajouter une tâche</router-link>
            </div>
        </div>

        <table class="table table-striped table-hover table-bordered">
            <thead>
                <tr>
                    <th>CustomerId</th>
                    <th>Task</th>
                    <th>StateTask</th>
                    <th>Options</th>
                </tr>
            </thead>

            <tbody>
                <tr v-if="wishList.length == 0">
                    <td colspan="6" class="text-center">Il n'y a actuellement aucune tâche</td>
                </tr>

                <tr v-if="id==i.customerId" v-for="i of wishList">
                    <td>{{ i.customerId }}</td>
                    <td>{{ i.task }}</td>
                    <td>{{ i.stateTask }}</td>
                    <td>
                        <router-link :to="`WishListe/edit/${i.taskId}`" ><i class="fa fa-pencil"></i></router-link>
                        <a href="#" @click="deleteWishListAsync(i.taskId)"><i class="fa fa-trash"></i></a>
                    </td>
                </tr>
            </tbody>
        </table>
         
    </div>
</template>

<script>
    import { getWishListAsync, deleteWishListAsync } from '../../api/wishListApi'
    import {getUserIdAsync, getUserTypeAsync} from'../../api/UserApi'

    export default {
        data() {
            return {
                wishList:[],
                pageNumber: 0,
                id : 0
            }
        },
        props:{
            size:{
            type:Number,
            required:false,
            default: 10
            }
        },
        async mounted() {
            await this.refreshList();
        },

        methods: {
            
            async refreshList() {
                try {
                    this.wishList = await getWishListAsync();
                    this.id = await getUserIdAsync();
                  
                    console.log(this.wishList);
                    console.log(this.wishListPerso);
                    console.log(this.id);
                    console.log( this.customerId);
                }
                catch(e) {
                    console.error(e);
                }
            },

            async deleteWishList(wishListId) {
                try {
                    await deleteWishListAsync(wishListId);
                    await this.refreshList();
                }
                catch(e) {
                    console.error(e);
                }
            }
            
        }
       
        
    }
</script>

<style lang="scss">

</style>