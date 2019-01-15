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
        this.type = await getUserTypeAsync();
        await this.test();
Console.log(this.type);

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
            // console.log("hdfyuhklj");
            //  if(this.type== false)
            //     document.body.style.backgroundImage = "url('https://c.wallhere.com/photos/f7/c5/rings_wedding_love_patterns-675008.jpg!d')";
            // else
            //     document.body.style.backgroundImage = "url('http://www.shafitriwedding.com/wp-content/uploads/2017/07/wedding-organizer-bekasi.jpg')";
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

