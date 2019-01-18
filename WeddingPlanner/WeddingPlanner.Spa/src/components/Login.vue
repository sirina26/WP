<template>
    <div>
        <div class="text-center">
            <h1 class="my-4">Bienvenue sur WeddingOrganizer</h1>
            <button type="button" @click="login('Base')" class="btn btn-lg btn-block btn-default">Se connecter via WeddingOrganizer</button>
        </div>
    </div>
</template>


<script>
import AuthService from '../services/AuthService'
import {getUserTypeAsync} from'../api/UserApi'


export default {
    data() {
        return {
            endpoint: null,
            document: document.body,
            type : true
        }
    },

   async mounted() {
        AuthService.registerAuthenticatedCallback(() => this.onAuthenticated());
        await this.test();

    },

    async beforeDestroy() {
        AuthService.removeAuthenticatedCallback(() => this.onAuthenticated());
    },

    methods: {
       async login(provider) {
            AuthService.login(provider);
        },

       async onAuthenticated() {
            this.$router.replace('/');
        }, 
        async test(){
          
        }
    }
}
</script>

<style lang="scss">
body{
    background-repeat: no-repeat;
    .button5 {border-radius: 50%;}
}
</style>

