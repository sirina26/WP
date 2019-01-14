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
           
            
            <button type="submit" class="btn btn-primary" @click="openDialog">Envoie</button>

    
            <div id="app">
                <a11y-dialog id="app-dialog" app-root="#app" @dialog-ref="assignDialogRef">
                    <h1 slot="title">email envoyé</h1>
                </a11y-dialog>
            </div>  
        </form>
    </div>
</template>

<script>
    import { getMailAsync, createMailAsync, updateMailAsync  } from '../../api/mailingApi'
    export default {
          name: 'YourComponent',

        data () {
            return {
                item: {},
                mode: null,
                id: null,
                errors: [],
                dialog: null,

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
                   
                }
            },
            openDialog () {
      if (this.dialog) {
        this.dialog.show()
      }
    },

        assignDialogRef (dialog) {
        this.dialog = dialog
            }
    }
}
</script>