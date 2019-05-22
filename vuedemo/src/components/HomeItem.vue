<template>
    <div class="card">
        <div class="card-body">
            <h4 class="card-title">{{item.title}}</h4>
                <p class="card-text">{{item.context!=null?item.context.substring(0,100):'null'}}</p>
                <p>作者：{{item.auther}} 时间：{{item.date}}</p>
            <router-link  class="card-link" v-bind:to="'/article/' + item.id">详细内容</router-link>
        </div>
    </div>
</template>

<script>
export default {
  name: 'HomeItem',
  data:function(){
      return {
      }
  },
  props:['item']
  ,
  methods:{
    
  },
  created() {
    //this.getData();
  },
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>


.list{
  margin-top: 10px;
}
.listItem:hover{
  background:#38424c; 
  color: aliceblue
}
</style>
