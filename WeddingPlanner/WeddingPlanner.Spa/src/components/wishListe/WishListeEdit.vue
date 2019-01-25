<template>
    <div>
        <div class="mb-4">
            <h1 v-if="mode == 'create'">Liste des choses à faire</h1>
            <h1 v-else>Editer la liste des choses à faire</h1>
        </div>

        <form @submit="onSubmit($event)">
            <div class="alert alert-danger" v-if="errors.length > 0">
                <b>Les champs suivants semblent invalides : </b>
                <ul>
                    <li v-for="e of errors">{{e}}</li>
                </ul>
            </div>

            <div class="form-group">
                <label class="required">Tâche : </label>
                <input type="text" v-model="item.task" class="form-control" required>
            </div>
           <!--  -->
            <input type="radio" id="true" value="true" v-model="item.stateTask" checked>
            <label for="true">Faite</label>
            <input type="radio" id="false" value="false" v-model="item.stateTask">
            <label for="false">Pas faite</label>
           <!--  -->
            <button type="submit" button5 class="btn btn-primary">Sauvegarder</button>

        </form>
    </div>
</template>

<script>
    import { getWishListAsync, createTaskAsync, updateWishListAsync, getWishAsync } from '../../api/wishListApi'
    import { DateTime } from 'luxon'
    import {getUserIdAsync, getUserTypeAsync} from'../../api/UserApi'


    export default {
        data () {
            return {
                item: {},
                mode: null,
                id: 0,
                wishListId: null,
                // id: null,
                errors: [],
                stateTask: null
            }
        },

        async mounted() {
            debugger;
            this.mode = this.$route.params.mode;
            this.id = await getUserIdAsync();     
            this.wishListId = this.$route.params.id;

            if(this.mode == 'edit') {
                try {
                     const item = await getWishAsync(this.wishListId);
                    // debugger;

                    // Here we transform the date, because the HTML date input expect format "yyyy-MM-dd"
                    item.WeddingDate = DateTime.fromISO(item.WeddingDate).toISODate();

                    this.item = item;
                }
                catch(e) {
                    console.error(e);
                    this.$router.replace('/WishListeEdit');
                }
            } 
        },

        methods: {
            async onSubmit(event) {
                
                event.preventDefault();
                var errors = [];
                this.errors = errors;
                this.item.customerId = this.id;
                // this.item.stateTask = this.stateTask;
                console.log(this.item);
                if(errors.length == 0) {
                    try {
                        if(this.mode == 'create') {
                            await createTaskAsync(this.item);
                        }
                        else {
                           await updateWishListAsync(this.item);
                        }
                        this.$router.replace('/wishListe/');
                    }
                    catch(e) {
                        console.error(e);
                        // this.$router.replace('./');

                    }
                }
            }
        }
    }
</script>

<style lang="scss">

</style>