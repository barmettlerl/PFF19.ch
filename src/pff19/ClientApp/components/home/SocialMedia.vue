<template>
  <div class="social-media">
    <img :src="require('assets/images/social_media_top_overlay.svg')" class="top-overlay" />
    <img
      :src="require('assets/images/pattern_red_right.svg')"
      class="right-overlay d-none d-xl-block"
    />
    <div class="container">
      <div class="row flex-md-row-reverse">
        <div class="col-md-4 col-12">
          <h2>Social Media</h2>
        </div>
        <div class="col-md-12 col-12">
          <iframe
            src="https://www.facebook.com/plugins/page.php?href=https%3A%2F%2Fwww.facebook.com%2Fpff19mosaik%2F&tabs=timeline&width=340&height=500&small_header=false&adapt_container_width=true&hide_cover=false&show_facepile=true&appId"
            width="100%"
            height="500"
            style="border:none;overflow:hidden"
            scrolling="no"
            frameborder="0"
            allowTransparency="true"
            allow="encrypted-media"
          ></iframe>
        </div>
      </div>
    </div>
    <img :src="require('assets/images/social_media_bottom_overlay.svg')" class="bottom-overlay" />
  </div>
</template>

<script></script>

<style lang="scss" scoped>
.social-media {
  width: 100%;
  height: 950px;
  background: #c20812;
  margin-top: 50px;
  padding: 175px 0 100px 0;
  color: white;
  position: relative;
}

.top-overlay {
  position: absolute;
  top: -2px;
}

.right-overlay {
  position: absolute;
  width: 20%;
  right: 0;
  top: -30px;
}

.bottom-overlay {
  position: absolute;
  bottom: -2px;
}

@media (max-width: 768px) {
  .social-media {
    padding: 100px 0 50px 0;
    height: 800px;
  }
}
</style>
