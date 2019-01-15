<template>
    <div id="app" :class="classObject" class="main">
        <header>
            <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
                <router-link class="navbar-brand" to="/">WeddingOrganizer</router-link>

                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>

                <div class="collapse navbar-collapse" id="navbarSupportedContent" v-if="auth.isConnected">
                    <ul class="navbar-nav mr-auto">
                        <li class="nav-item">
                            <router-link class="nav-link" to="/wishListe" v-if="type == false">Gestion de liste</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link class="nav-link" to="/event">Gestion d'évènement</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link class="nav-link" to="/mailing">Gestion des e-mails</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link class="nav-link" to="/messaging">Gestion des Message</router-link>
                        </li>
                    </ul>

                    <ul class="navbar-nav my-2 my-md-0">
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                {{ auth.email }}
                            </a>
                            <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                                <router-link class="dropdown-item" to="/logout">Se déconnecter</router-link>
                            </div>
                        </li>
                    </ul>
                </div>
            </nav>

            <div class="progress" v-if="isLoading">
                <div class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 100%"></div>
            </div>
        </header>

        <main role="main" class="p-3 p-md-4 p-lg-5">
            <router-view class="child"></router-view>
        </main>
    </div>
</template>

<script>

import AuthService from '../services/AuthService'
import '../directives/requiredProviders'
import { state } from "../state"
import {getUserIdAsync, getUserTypeAsync} from'../api/UserApi'


export default {
    data() {
        return {
            state,
            type: false,
        }
    }, 
    async beforeUpdate() { 
                            
            this.type = await getUserTypeAsync();
        },

    computed: {
        auth: () => AuthService,
        
        isLoading() {
            return this.state.isLoading;
        },

        classObject() {
            return {
                'customer-background': !this.type,
                'organizer-background': this.type
            }
        }
    }
}
</script>

<style lang="scss" scoped>
.progress {
  margin: 0px;
  padding: 0px;
  height: 5px;
}

a.router-link-active {
  font-weight: bold;
}
</style>

<style lang="scss">
@import "../styles/global.scss";
</style>