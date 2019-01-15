<template>
    <div>
        <div class="mb-4 d-flex justify-content-between">
            <h1>Gestion d'événement </h1>

            <div>
                <router-link class="btn btn-primary" :to="`event/create`" v-if="type == false"><i class="fa fa-plus"></i> Ajouter un événement</router-link>
            </div>
        </div>

        <table class="table table-striped table-hover table-bordered">
            <thead>
                <tr> <th>id</th>
                    <th>Nom</th>
                    <th>ID de Client</th>
                    <th>Endroit</th>
                    <th>Prix maximum </th>
                    <th>Date </th> 
                    <th>Nombre d'invités</th>
                    <th>Remarques</th>
                    <th>Option</th>                    
                </tr>
            </thead>

            <tbody>
                <tr v-if="eventList.length == 0">
                    <td colspan="6" class="text-center">Il n'y a actuellement aucun event.</td>
                </tr>

                <tr v-for="i of paginatedData" v-if="i.customerId!=0"> 
                    {{i.eventId}}
                    <td>{{ i.eventName }}</td>
                    <td>{{ i.customerId }}</td>
                    <td>{{ i.place }}</td>
                    <td>{{ i.maximumPrice }}</td>
                    <td>{{ new Date(i.weddingDate).toLocaleDateString() }}</td>
                    <td>{{ i.numberOfGuestes }}</td>
                    <td>{{ i.note }}</td>                     
                    <td> 
                        <a @click="deleteEvent(i.eventId)" v-if="i.customerId === id"><i class="fa fa-trash"></i></a>
                        <a @click="commentEvent(i.eventId)" v-if="type === true"><i class="fa fa-comments-o"></i></a>
                        <router-link :to="`event/edit/${i.eventId}`"  v-if="i.customerId === id"><i class="fa fa-pencil"></i></router-link>
                    </td>  
                  
                </tr>
            </tbody>
        </table>
          <button 
            :disabled="pageNumber === 0" 
            @click="prevPage">
            Previous
        </button>
        <button 
            :disabled="pageNumber > pageCount -1" 
            @click="nextPage">
            Next
        </button>
    </div>
</template>

<script>
    import { getEventListAsync, deleteEventAsync } from '../../api/eventApi'
    import AuthService from '../../services/AuthService'
    import {getUserIdAsync, getUserTypeAsync} from'../../api/UserApi'

    export default {
        data() {
            return {
                eventList:[],
                pageNumber: 0, 
                id : 0,
                type : true
            }
        },
        props:{
            size:{
            type:Number,
            required:false,
            default: 7
            }
        },
        async mounted() {
           
            await this.refreshList();
            this.id = await getUserIdAsync();     
            this.type = await getUserTypeAsync();  
            

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
            },
             nextPage(){
                 this.pageNumber++;
            },
            
            prevPage(){
                this.pageNumber--;
            }
        },
        computed:
        {
            auth: () => AuthService,
            pageCount(){  
                if(this.eventList !== "undefined")          
                {
                    let l = this.eventList.length,
                    s = this.size;
                    return Math.floor(l/s);
                }
                
            },
            paginatedData(){
                const start = this.pageNumber * this.size,
                end = start + this.size;
                return this.eventList.slice(start, end);
            } 
        }  
        
    }
</script>

<style lang="scss">

</style>