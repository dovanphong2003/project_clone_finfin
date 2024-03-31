<script setup lang="ts">
defineProps({
  titleModal: {
    type: String,
    required: true
  },
  activeModal: {
    type: Boolean,
    required: true
  },
  disableModal: {
    type: Boolean,
    required: true
  },
  handleClickCloseModal: {
    type: void Function
  }
})
</script>
<template>
  <div
    :class="[
      activeModal ? 'active_modal' : '',
      disableModal ? 'disable_scroll_modal' : '',
      'box_modal'
    ]"
  >
    <div @click="$emit('handleClickCloseModal')" class="shadow_modal"></div>
    <div
      :class="[
        activeModal ? 'active_modal' : '',
        disableModal ? 'disable_scroll_modal' : '',
        'modal'
      ]"
    >
      <div class="content_modal">
        <div class="close_modal">
          <!--slot of modal-->
          <p class="title_modal">{{ titleModal }}</p>
          <img @click="$emit('handleClickCloseModal')" src="/icon/close.png" alt="" />
        </div>
        <div class="main_content_modal">
          <slot />
        </div>
      </div>
    </div>
  </div>
</template>
<style lang="scss" scoped>
.box_modal {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  z-index: 5;
  transform: translate(100%, 0%);
  .shadow_modal {
    display: inline-block;
    width: 100%;
    height: 100%;
    background-color: rgba(0, 0, 0, 0.5);
  }
  .modal {
    padding: 60px 70px 100px 70px;
    position: absolute;
    right: 0;
    top: 0;
    width: 25%;
    height: 100%;
    transform: translate(100%, 0%);
    background-color: white;
    z-index: 10;
    .content_modal {
      .close_modal {
        padding-bottom: 20px;
        display: flex;
        align-items: center;
        justify-content: space-between;
        .title_modal {
          font-size: 14px;
          font-weight: 500;
          color: $color_default_for_text;
        }
        img {
          padding: 10px;
          height: 24px;
          width: 24px;
          cursor: pointer;
        }
      }
    }
  }
}
.disable_scroll_modal {
  animation: ease-in slideLefttToRight 0.5s forwards;
}
.active_modal {
  display: block;
  animation: ease-in slideRightToLeft 0.5s forwards;
}

@keyframes slideRightToLeft {
  0% {
    transform: translate(100%, 0%);
  }
  100% {
    transform: translate(0%, 0%);
  }
}

@keyframes slideLefttToRight {
  0% {
    transform: translate(0%, 0%);
  }
  100% {
    transform: translate(100%, 0%);
  }
}
</style>
