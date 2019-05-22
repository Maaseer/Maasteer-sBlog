<template>
  <div id="home" class="d-flex flex-column">
      <div class="list-group list">
        
        <home-item
          v-for="(item,index) in items"
          v-bind:key="index"
          v-bind:item="item"
        ></home-item>
        
      </div>
      <div class="page">
        <ul class="pagination">
          <li class="page-item"><a class="page-link" href="#" @click="changePage">上一页</a></li>
          <li class="page-item active"><a class="page-link" href="#">1</a></li>
          <li class="page-item "><a class="page-link" href="#">2</a></li>
          <li class="page-item"><a class="page-link" href="#">3</a></li>
          <li class="page-item"><a class="page-link" href="#">下一页</a></li>
        </ul>
      </div>

  </div>
</template>

<script>
import homeItem from './HomeItem'

export default {
  name: 'Home',
  data:function(){
      return {
          items:[],
          lastPageIndex:-1,
          nextPageIndex:-1,
          url:'api/index'
      }
  },
  methods:{
    getData:function(index=0){
      var vm = this;
      vm.$http.get(vm.$host + 'index?pageIndex=' + index).then(function(response){
        vm.items = response.data.value;
        
        console.log(response.headers);
      });
    },
    changePage(url){

    }
  },
  created() {
    this.getData();
  },
  components:{
    homeItem
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h1{
  margin: auto
}
.page{
  margin-top: auto;
  margin-left: auto;
  margin-right: auto;
}
.list{
  margin-top: 10px;
}
.listItem:hover{
  background:#38424c; 
  color: aliceblue
}
</style>
