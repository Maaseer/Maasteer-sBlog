<template>
    <div>
        
        <right-nav-item
            v-for="(item,index) in items"
            v-bind:key="index"
            v-bind:item="item"
            @itemClick="itemClick"
        ></right-nav-item>

        <img alt="Vue logo" src="../assets/logo.png">
    </div>
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
    this.$http.get('http://localhost:6000/api/index').then(function(response){
        vm.items = response.data.value;
    })
  },
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
