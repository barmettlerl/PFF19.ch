<template>
  <div v-if="mainSponsors && mainSponsors.length > 0" class="sponsors container">
    <h2>{{ $t('lang.components.home.sponsors.main_sponsors') }}</h2>
    <div class="row">
      <app-sponsor v-for="sponsor in mainSponsors" :key="sponsor.id" :sponsor="sponsor">
      </app-sponsor>
    </div>
  </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
import Sponsor from './Sponsor.vue'

export default {
  components: {
    'app-sponsor': Sponsor
  },

  computed: {
    ...mapGetters('sponsors', ['mainSponsors'])
  },

  created() {
    this.load()
  },

  methods: {
    ...mapActions('sponsors', ['load'])
  }
}
</script>

<style lang="scss" scoped>
.sponsors {
  width: 100%;
  margin-top: 50px;
}
</style>
