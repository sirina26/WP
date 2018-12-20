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
import Vue from 'vue'

export default {
    data() {
        return {
            endpoint: null
        }
    },

    mounted() {
        AuthService.registerAuthenticatedCallback(() => this.onAuthenticated());
    },

    beforeDestroy() {
        AuthService.removeAuthenticatedCallback(() => this.onAuthenticated());
    },

    methods: {
        login(provider) {
            AuthService.login(provider);
        },

        onAuthenticated() {
            this.$router.replace('/');
        }
    }
}
</script>

<style lang="scss">

body{
    background-image: url("https://c.wallhere.com/photos/f7/c5/rings_wedding_love_patterns-675008.jpg!d");
    background-repeat: no-repeat;
    .button5 {border-radius: 50%;}

}
</style>

