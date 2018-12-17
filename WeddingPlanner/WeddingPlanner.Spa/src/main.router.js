// Vue router setup
import Vue from 'vue';
import VueRouter from 'vue-router';
Vue.use(VueRouter);

import requireAuth from './helpers/requireAuth';

// Components
import Home from './components/Home.vue'
import Login from './components/Login.vue'
import Logout from './components/Logout.vue'

import PlaygroundPage from './components/playground/PlaygroundPage.vue'


import EventList from './components/event/EventList.vue'
import EventEdit from './components/event/EventEdit.vue'

import MailingEdit from './components/mailing/Mail.vue'
import InvitationEdit from './components/Invitation/Invitation.vue'

import WishListeEdit from './components/wishListe/WishListeEdit.vue'
import WishListe from './components/wishListe/WishListe.vue'


const routes = [
    { path: '', component: Home, beforeEnter: requireAuth },
    
    { path: '/login', component: Login },
    { path: '/logout', component: Logout, beforeEnter: requireAuth },
    { path: '/playground', component: PlaygroundPage },

   
    { path: '/event', component: EventList, beforeEnter: requireAuth },
    { path: '/event/:mode([create|edit]+)/:id?', component: EventEdit, beforeEnter: requireAuth },
    { path: '/event/:mode([create|edit]+)/', component: EventEdit, beforeEnter: requireAuth },

    { path: '/mailing', component: MailingEdit, beforeEnter: requireAuth },
    { path: '/mailing/:mode([create|edit]+)/', component: MailingEdit, beforeEnter: requireAuth },
    
    { path: '/wishListe', component: WishListe, beforeEnter: requireAuth },
    { path: '/WishListe/:mode([create|edit]+)/', component: WishListeEdit, beforeEnter: requireAuth },
    { path: '/WishListe/:mode([create|edit]+)/:id?', component: WishListeEdit, beforeEnter: requireAuth },

    { path: '/Invitation', component: InvitationEdit }
];

export default new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes
});