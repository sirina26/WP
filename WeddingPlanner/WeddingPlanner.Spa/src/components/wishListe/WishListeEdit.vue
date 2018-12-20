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

            <button type="submit" button5 class="btn btn-primary">Sauvegarder</button>

        </form>
    </div>
</template>

<script>
    import { getWishListAsync, createTaskAsync, updateWishListAsync } from '../../api/wishListApi'
    import { DateTime } from 'luxon'

    export default {
        data () {
            return {
                item: {},
                mode: null,
                id: null,
                errors: [],
            }
        },

        async mounted() {
            debugger;
            this.mode = this.$route.params.mode;
            this.id = this.$route.params.id;
            
            if(this.mode == 'edit') {
                try {
                    const item = await getWishListAsync(this.id);
                    debugger;

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
debugger;
                if(errors.length == 0) {
                    try {
                        if(this.mode == 'create') {
                            await createTaskAsync(this.item);
                        }
                        else {
                            await updateWishListAsync(this.item);
                        }

                        this.$router.replace('../wishListe');
                    }
                    catch(e) {
                        console.error(e);
                    }
                }
            }
        }
    }
</script>

<style lang="scss">

</style>