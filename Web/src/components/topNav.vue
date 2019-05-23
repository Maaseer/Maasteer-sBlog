<template>
    <nav id="top-nav" class="navbar navbar-expand-sm bg-dark navbar-dark fixed-top ">
        <strong><router-link class="navbar-brand" to="/">Maasteer's blog</router-link></strong>
        <ul class="navbar-nav ml-auto" >
            <!-- <li class="nav-item">
                <router-link class="nav-link" to="/message">留言</router-link>
            </li> -->
        </ul>
        <div class="form-inline flex-row-reverse">
                <router-link class="btn btn-primary" v-bind:to="'/' + searchStr">
                    搜索
                </router-link>
                <input class="form-control" type="text" v-model="searchStr" placeholder="Search" @keyup.enter="searchClick">
        </div>
    </nav>
</template>

<script>
export default {
  name: 'topNav',
  props: {

  },
  data() {
      return {
          searchStr:'',
      }
  },
  methods: {
      searchClick:function(){
          var vm = this;
          vm.$router.push('/' + vm.searchStr);
      }
  },
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
