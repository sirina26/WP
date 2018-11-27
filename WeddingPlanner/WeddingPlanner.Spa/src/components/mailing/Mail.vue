<template>
    <div>
        <div class="mb-4">
            <h1 v-if="mode == 'create'">Créer un mail</h1>
        </div>

        <form @submit="onSubmit($event)">
            <div class="alert alert-danger" v-if="errors.length > 0">
                <b>Les champs suivants semblent invalides : </b>
                <ul>
                    <li v-for="e of errors">{{e}}</li>
                </ul>
            </div>

            <div class="form-group">
                <label class="required">A</label>
                <input type="text" v-model="item.ToName" class="form-control" required>
            </div>

            <div class="form-group">
                <label class="required">Object</label>
                <input type="text" v-model="item.ObjectMail" class="form-control" required>
            </div>

            <div class="form-group">
                <label class="required">Mail</label>
                <input type="textbox" v-model="item.Mail" class="form-control" required>
            </div>
            
            <button type="submit" class="btn btn-primary">Envoie</button>

        </form>
    </div>
</template>

<script>
    import { getMailAsync, createMailAsync, updateMailAsync } from '../../api/mailingApi'
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
            
            this.mode = this.$route.params.mode;
            this.id = this.$route.params.id;
            debugger;
            if(this.mode == 'edit') {
                try {
                    const item = await getMailAsync(this.id);
                    this.item = item;
                }
                catch(e) {
                    console.error(e);
                    this.$router.replace('/mailing');
                }
            }
        },

        methods: {
            async onSubmit(mailing) {
                mailing.preventDefault();

                var errors = [];
                
                if(!this.item.WeddingDate) errors.push("Date de l'évènement")
                this.errors = errors;

                if(errors.length == 0) {
                    try {
                        if(this.mode == 'create') {
                            debugger;
                            await createMailAsync(this.item);
                        }
                        else {
                            await updateMailAsync(this.item);
                        }

                        this.$router.replace('../mailing');
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