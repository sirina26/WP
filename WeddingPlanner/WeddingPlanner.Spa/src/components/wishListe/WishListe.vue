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
                    <th>TaskId</th>
                    <th>CustomerId</th>
                    <th>Task</th>
                    <th>StateTask</th>
                </tr>
            </thead>

            <tbody>
                <tr v-if="wishList.length == 0">
                    <td colspan="6" class="text-center">Il n'y a actuellement aucune tâche</td>
                </tr>

                <tr v-for="i of paginatedData">
                    <td>{{ i.taskId }}</td>
                    <td>{{ i.customerId }}</td>
                    <td>{{ i.task }}</td>
                    <td>{{ i.stateTask }}</td>
                    <td>
                        <router-link :to="`WishListe/edit/${i.taskId}`"><i class="fa fa-pencil"></i></router-link>
                        <a href="#" @click="deleteWishListAsync(i.taskId)"><i class="fa fa-trash"></i></a>
                        <a href="#" @click="deleteWishListAsync(i.taskId)"><i class="fa fa-comments-o"></i></a>
                    </td>
                </tr>
            </tbody>
        </table>
          <button 
            :disabled="pageNumber === 0" 
            @click="prevPage">
            Previous
        </button>
        <button 
            :disabled="pageNumber > pageCount -1" 
            @click="nextPage">
            Next
        </button>
    </div>
</template>

<script>
    import { getWishListAsync, deleteWishListAsync } from '../../api/wishListApi'

    export default {
        data() {
            return {
                wishList:[],
                pageNumber: 0
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
            },
             nextPage(){
                 this.pageNumber++;
            },
            
            prevPage(){
                this.pageNumber--;
            }
        },
        computed:
        {
            pageCount(){  
                if(this.wishList !== "undefined")          
                {
                    let l = this.wishList.length,
                    s = this.size;
                    return Math.floor(l/s);
                }
                
            },
            paginatedData(){
                const start = this.pageNumber * this.size,
                end = start + this.size;
                return this.wishList.slice(start, end);
            } 
        }  
        
    }
</script>

<style lang="scss">

</style>