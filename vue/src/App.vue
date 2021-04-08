<template>
  <div id="app" class="d-flex flex-column">
    <b-carousel
      id="carousel-1"
      class="carousel-img"
      v-model="slide"
      :interval="0"
      wrap
      @sliding-start="onSlideStart"
      @sliding-end="onSlideEnd"
    >
      <b-carousel-slide class="slide"
            img-src="https://cdn.citybeat.com/files/base/scomm/cb/image/2019/05/960w/NorthernRowBrewing_HB_15.5cdb2e7194008.jpg"
      ></b-carousel-slide>
      <b-carousel-slide class="slide"
        img-src="https://ohiomagazine.imgix.net/sitefinity/images/default-source/articles/2019/02---february-2019/madtree-interior-2.jpg?sfvrsn=74d9a938_2&w=960&auto=compress%2Cformat"
      ></b-carousel-slide>
      <b-carousel-slide class="slide"
        img-src="https://www.gannett-cdn.com/presto/2020/08/03/PCIN/aa09ec77-343e-4668-8974-7bcfe29701f4-Wiedemanns_Exterior_Front.jpg"
      ></b-carousel-slide>
    </b-carousel>

    <NavBar />

    <div class="container flex-grow-1 d-flex flex-column">
      <router-view />
    </div>
  </div>
</template>

<script>
import NavBar from "./components/NavBar";

export default {
  components: { NavBar },
};
</script> 
<style scoped>

.carousel-img{
  background-size: cover;
    background-attachment: fixed;

  position:absolute;
  width:100vw;
  height:100vh;

}

</style>