<template>
    <div>
        <div class="mb-4">
            <h1 v-if="mode == 'create'">Créer un évènement</h1>
            <h1 v-else>Editer un évènement</h1>
        </div>

        <form @submit="onSubmit($event)">

            <template v-if="item !== null">
                <div class="form-group">
                    <label class="required">Nom de l'évènement</label>
                    <input type="text" v-model="item.eventName" class="form-control" required>
                </div>

                <div class="form-group">
                    <label class="required">Place de l'évènement</label>
                    <input type="text" v-model="item.place" class="form-control" required>
                </div>

                <div class="form-group">
                    <label class="required">Nombre d'invités</label>
                    <input type="number" v-model="item.numberOfGuestes" class="form-control" required>
                </div>

                <div class="form-group">
                    <label class="required">Prix maximum</label>
                    <input type="float" v-model="item.maximumPrice" class="form-control" required>
                </div>

                <div class="form-group">
                    <label class="required">Remarques</label>
                    <input type="text" v-model="item.note" class="form-control" required>
                </div>

                <div class="form-group">
                    <label class="required">Date de l'évènement </label>
                    <input type="date" v-model="item.weddingDate" class="form-control" required>
                </div>
            </template>
            
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
                eventid: null,
                errors: [],
            }
        },

        async mounted() {
            
            this.mode = this.$route.params.mode;
            this.eventid = this.$route.params.id;
            if(this.mode == 'edit') {
                try {
                    const item = await getEventAsync(this.eventid);
                    item.weddingDate = DateTime.fromISO(item.weddingDate).toFormat('yyyy-MM-dd');
                    this.item = item;
                 
                }
                catch(e) {
                    console.error(e);
                    this.$router.replace('./');
                }
            }
             console.log(this.item); 
          
        },

        methods: {
            async onSubmit(e) {
                e.preventDefault();

                var errors = [];
                
                if (isNaN(parseFloat(this.item.maximumPrice)))
                    alert("Prix maximum n'est pas valide!");
                          
                if(!this.item.birthDate)
                    errors.push("Date de naissance");
      
                this.errors = errors;

                if(errors.length == 0) {
                    try {
                        if(this.mode == 'create') {
                            await createEventAsync(this.item);
                        }
                        else {
                            await updateEventAsync(this.item);
                            debugger;
                        }

                        this.$router.replace('./');
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