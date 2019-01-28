<template>
    <div>
        <div class="mb-4 d-flex justify-content-between">
            <h1>Gestion d'événement </h1>

            <div>
                <router-link class="btn btn-primary" :to="`./create`" v-if="type == false"><i class="fa fa-plus"></i> Ajouter un événement</router-link>
            </div>
        </div>

        <table class="table table-striped table-hover table-bordered">
            <thead>
                <tr> 
                    <th>Nom de l'évènement</th>
                    <th>Nom de Client</th>
                    <th>Endroit</th>
                    <th>Prix maximum </th>
                    <th>Date </th> 
                    <th>Nombre d'invités</th>
                    <th>Remarques</th>
                    <th>Option</th>   
                    <th>Commentaire</th>                 
                </tr>
            </thead>

            <tbody>
                <tr v-if="eventList.length == 0">
                    <td colspan="6" class="text-center">Il n'y a actuellement aucun event.</td>
                </tr>

                <tr v-for="i of paginatedData" v-if="i.customerId!=0"> 
                   
                    
                    <td>{{ i.eventName }}</td>
                    <td>{{ i.firstName }}</td>
                    <td>{{ i.place }}</td>
                    <td>{{ i.maximumPrice }}</td>
                    <td>{{ new Date(i.weddingDate).toLocaleDateString() }}</td>
                    <td>{{ i.numberOfGuestes }}</td>
                    <td>{{ i.note }}</td>                     
                    <td> 
                        <a @click="deleteEvent(i.eventId)" v-if="i.customerId === id"><i class="fa fa-trash"></i></a>
                        <router-link :to="`./comment/${i.eventId}`" v-if="type === true"><i class="fa fa-comments-o"></i></router-link>
                        <router-link :to="`event/edit/${i.eventId}`"  v-if="i.customerId === id"><i class="fa fa-pencil"></i></router-link>
                    </td>  
                    <ul>
                        <li v-for="j in commentList" v-if="i.eventId==j.eventId">
                            <!-- {{j.organizerId}} -->
                            {{j.proposition}}<br>
                            {{new Date(j.propositionDate).toLocaleDateString()}} à
                            {{new Date(j.propositionDate).toLocaleTimeString()}}
                        </li>
                    </ul>
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
    import {getCommentListAsync} from '../../api/commentApi'
    import AuthService from '../../services/AuthService'
    import {getUserIdAsync, getUserTypeAsync} from'../../api/UserApi'

    export default {
        data() {
            return {
                eventList:[],
                commentList:[],
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
             
            if(this.mode == 'edit') {
                try {
                    const item = await getUserIdAsync(this.id);
                     
                    // Here we transform the date, because the HTML date input expect format "yyyy-MM-dd"
                    
                    this.item = item;
                }
                catch(e) {
                    console.error(e);
                    this.$router.replace('/event');
                }
            }

        },

        methods: {
            
            async refreshList() {
                try {   
                    this.commentList = await getCommentListAsync();
                    this.eventList = await getEventListAsync();
                    console.log(this.eventList);
                    // console.log(this.commentList.propositionDate);
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