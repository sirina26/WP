<template>
    <div>
        <div class="mb-4 d-flex justify-content-between">
            <h1>Gestion d'événement </h1>

            <div>
                <router-link class="btn btn-primary" :to="`event/create`"><i class="fa fa-plus"></i> Ajouter un événement</router-link>
            </div>
        </div>

        <table class="table table-striped table-hover table-bordered">
            <thead>
                <tr>
                    <th>Nom de l'événement</th>
                    <th>ID  de Client</th>
                    <th>ID  de Organizateur</th>
                    <th>Endroit de l'événement</th>
                    <th>Prix maximum de l'événement</th>
                   <th>date de l'événement</th> 
                    <th>Nombre d'invités</th>
                    <th>Remarques</th>
                    <th>Option</th>
                </tr>
            </thead>

            <tbody>
                <tr v-if="eventList.length == 0">
                    <td colspan="6" class="text-center">Il n'y a actuellement aucun event.</td>
                </tr>

                <tr v-for="i of eventList">
                    <td>{{ i.eventName }}</td>
                    <td>{{ i.customerId }}</td>
                    <td>{{ i.organizerId }}</td>
                    <td>{{ i.place }}</td>
                    <td>{{ i.maximumPrice }}</td>
                    <td>{{ new Date(i.WeddingDate).toLocaleDateString() }}</td>
                    <td>{{ i.numberOfGuestes }}</td>
                    <td>{{ i.note }}</td>
                    <td>
                        <router-link :to="`event/edit/${i.eventtId}`"><i class="fa fa-pencil"></i></router-link>
                        <a href="#" @click="deleteEvent(i.eventtId)"><i class="fa fa-trash"></i></a>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
    import { getEventListAsync, deleteEventAsync } from '../../api/eventApi'

    export default {
        data() {
            return {
                eventList: []
            }
        },

        async mounted() {
            await this.refreshList();
        },

        methods: {
            async refreshList() {
                try {
                    this.eventList = await getEventListAsync();

                }
                catch(e) {
                    console.error(e);
                }
            },

            async deleteEvent(eventId) {
                try {
                    await deleteEventAsync(eventId);
                    await this.refreshList();
                }
                catch(e) {
                    console.error(e);
                }
            }
        }
    }
</script>

<style lang="scss">

</style>