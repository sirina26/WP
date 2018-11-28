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
                <input type="email" v-model="item.MailAdress" class="form-control" required>
            </div>

            <div class="form-group">
                <label class="required">Object</label>
                <input type="text" v-model="item.ObjectMail" class="form-control" required>
            </div>

            <span class="required">Mail</span><br>
            <div class="input-group">
                <textarea class="form-control" aria-label="With textarea" v-model="item.Mail"></textarea>

            </div>
           
            
            <button type="submit" class="btn btn-primary">Envoie</button>

        </form>
    </div>
</template>

<script>
    import { getMailAsync, createMailAsync, updateMailAsync } from '../../api/mailingApi'

    export default {
        data () {
            return {
                item: {},
                mode: null,
                id: null,
                errors: [],
            }
        },

        methods: {
            async onSubmit(mailing) {
                mailing.preventDefault();

                var errors = [];
                
                this.errors = errors;

                if(errors.length == 0) {
                  debugger;
                  await createMailAsync(this.item);
                       
                        ///this.$router.replace('../mailing');
                   
                }
            }
        }
    }
</script>

<style lang="scss">

</style>