<template>
    <div>
        <div class="mb-4">
            <h1 v-if="mode == 'create'">Créer un évènement</h1>
            <h1 v-else>Editer un évènement</h1>
        </div>

        <form @submit="onSubmit($event)">
            <div class="alert alert-danger" v-if="errors.length > 0">
                <b>Les champs suivants semblent invalides : </b>

                <ul>
                    <li v-for="e of errors">{{e}}</li>
                </ul>
            </div>

            <div class="form-group">
                <label class="required">Nom</label>
                <input type="text" v-model="item.lastName" class="form-control" required>
            </div>

            <div class="form-group">
                <label class="required">Prénom</label>
                <input type="text" v-model="item.firstName" class="form-control" required>
            </div>

            <div class="form-group">
                <label class="required">Date de l'évènement </label>
                <input type="date" v-model="item.birthDate" class="form-control" required>
            </div>

            <button type="submit" class="btn btn-primary">Sauvegarder</button>
        </form>
    </div>
</template>

<script>
    import { getEventAsync, createEventAsync, updateEventAsync } from '../../api/eventApi'
    import { DateTime } from 'luxon'

    export default {
        data () {
            return {
                item: {},
                mode: null,
                id: null,
                errors: []
            }
        },

        async mounted() {
            this.mode = this.$route.params.mode;
            this.id = this.$route.params.id;
            
            if(this.mode == 'edit') {
                try {
                    const item = await getEventAsync(this.id);

                    // Here we transform the date, because the HTML date input expect format "yyyy-MM-dd"
                    item.birthDate = DateTime.fromISO(item.birthDate).toISODate();

                    this.item = item;
                }
                catch(e) {
                    console.error(e);
                    this.$router.replace('/event');
                }
            }
        },

        methods: {
            async onSubmit(event) {
                event.preventDefault();

                var errors = [];

                if(!this.item.lastName) errors.push("Nom")
                if(!this.item.firstName) errors.push("Prénom")
                if(!this.item.birthDate) errors.push("Date de naissance")

                this.errors = errors;

                if(errors.length == 0) {
                    try {
                        if(this.mode == 'create') {
                            await createEventAsync(this.item);
                        }
                        else {
                            await updateEventAsync(this.item);
                        }

                        this.$router.replace('/event');
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