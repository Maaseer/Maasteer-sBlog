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
          <li class="page-item"><a class="page-link" href="#" @click="changePage(params.pageIndex - 1)">上一页</a></li>


          <li v-for="i in pagination.pageCount" v-bind:key="i" class="page-item"><a class="page-link" href="#" @click="changePage(i)">{{i}}</a></li>


          <li class="page-item"><a class="page-link" href="#" @click="changePage(params.pageIndex + 1)">下一页</a></li>
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
          url:'api/index',
          pagination:{
            pageCount:0
          },

          params:{
            pageIndex:0,
            pageSize:10,
            orderBy:"date desc",
            contain:''
              
          }
      }
  },
  methods:{
    getData:function(){
      var vm = this;
      vm.$http.get(vm.$host + 'index',{params:vm.params}).then(function(response){
        vm.items = response.data.value;
        vm.pagination = JSON.parse(response.headers.pagination);
        vm.pagination.pageCount++;
        vm.params.pageIndex = vm.pagination.pageIndex+1;
        console.log(vm.params);
      });
    },
    //服务器中页数以0开始，Vue中的循环页数以1开始，因此需要在此加以转换
    changePage(index){
      var vm = this;
      index = index < 1?1:index;
      index = index > vm.pagination.pageCount?vm.pagination.pageCount:index;
      this.params.pageIndex = index - 1;
      this.getData();
    }
  },
  created() {
    this.getData();
  },
  components:{
    homeItem
  },
  watch: {
  '$route' (to, from) {
      var vm = this;

      vm.params.contain = vm.$route.params.searchStr;
      vm.params.pageIndex = 0;
      vm.getData();
    }
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
