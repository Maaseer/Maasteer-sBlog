<template>
        <nav class="navbar bg-dark">
            <h3>最新文章</h3>
            <br><br><br><br>
            <ul class="navbar-nav ">
                <right-nav-item
                    v-for="(item,index) in items"
                    v-bind:key="index"
                    v-bind:item="item"
                    @itemClick="itemClick"
                ></right-nav-item>   
            </ul>           
        </nav>
        <!--
    <div>
        <right-nav-item
            v-for="(item,index) in items"
            v-bind:key="index"
            v-bind:item="item"
            @itemClick="itemClick"
        ></right-nav-item>

        <img alt="Vue logo" src="../assets/logo.png">
    </div>-->
</template>

<script>
import rightNavItem from './rightNavItem.vue';

export default {
  name: 'rightNav',
  props: {
  },
  data(){
      return {
          items:[]
      }
  },
    methods:{
        itemClick:function (id) {
            this.$emit('rightNavItemClick',id);
        }
    }
  ,
  components:{
      rightNavItem
  },
    created(){
    var vm = this;
    this.$http.get(vm.$host+'index?pageSize=7&orderBy=date desc').then(function(response){
        vm.items = response.data.value;
    })
  },
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
a{
    color: #999;
        
}
a:hover{
    color: aliceblue;
}
nav{
    border-radius: 0.1in
}
ul{
    margin: auto
}
h3{
    margin:auto;
    color:salmon
}
</style>
