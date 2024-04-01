<script setup lang="ts">
import CptQuill from '@/common/components/CptQuill.vue'
import CptSlideShow from '@/modules/slideShow/CptSlideShow.vue'
import { ref, type Ref } from 'vue'
import breadCrumb from '@/modules/breadcrumb/breadCrumb.vue'
const contentCode: Ref<string> = ref('')

// using when test code use quill
const changeContentCode = (content: string) => {
  contentCode.value = content
}
const quantity: Ref<number> = ref(1)
const contentCodeDemo =
  '<p>Bộ sách&nbsp;<strong style="color: rgb(230, 126, 34);">"Kỹ năng và Phương pháp Giao dịch&nbsp;của các Trader Quản lý&nbsp;Quỹ "</strong><span style="color: rgb(230, 126, 34);">&nbsp;</span>tổng hợp các tựa sách giao dịch Forex nổi tiếng được viết bởi các Nhà Quản lý Quỹ, lượng kiến thức và kinh nghiệm chắc chắn sẽ rất lớn và bổ ích từ những cá nhân đã đạt vị trí cao và được công nhận trên Thế giới. Bộ sách bao gồm 3&nbsp;tựa&nbsp;như sau:</p><p class="ql-align-center"><img src="https://file.hstatic.net/1000297486/file/combo34_e4173f9080d04c90ac23c4f508602cf3_grande.jpg"></p><p>&nbsp;</p><h2><span style="color: rgb(0, 153, 204);">Khám Phá Nghệ Thuật Giao Dịch Tiền Tệ Chuyên Nghiệp</span></h2><p><strong><em>Khám phá Nghệ thuật Giao dịch Tiền tệ Chuyên nghiệp</em></strong>&nbsp;khái quát hầu như tất cả những yếu tố từ cơ bản nhất đến chuyên sâu nhất dành cho một FX Trader thành công, bao gồm:</p><ul><li>Vì sao giao dịch Forex được xem là nghệ thuật chứ không phải khoa học.</li><li>Câu chuyện “làm nghề” của một FX Trader cho ngân hàng - quỹ đầu cơ.</li><li>Những điểm mốc quan trọng trong lịch sử của thị trường Forex.</li><li>Cấu trúc thị trường Forex có gì đáng chú ý.</li><li>Phân tích cơ bản - Fundamental Analysis - thị trường Forex như thế nào để hiệu quả thông qua phân tích vĩ mô.</li><li>Cách thức giao dịch theo tin tức trên thị trường Forex.</li><li>Cách một FX Trader chuyên nghiệp sử dụng phân tích kỹ thuật, đặc biệt tác giả có chia sẻ 07 thiết lập giao dịch hiệu quả cao mà bản thân sử dụng.</li><li>Phân tích Liên thị trường - Intermarket Analysis - được sử dụng ra sao trên thị trường Forex.</li><li>Cách quản lý rủi ro, tính toán lượng vị thế giao dịch như thế nào để đạt hiệu quả cao mà không quá nguy hiểm đến tài khoản giao dịch.</li><li>Cách thức thấu hiểu bản thân để trở thành một FX Trader thành công.</li></ul><p>Đặc biệt là<strong>&nbsp;</strong><strong style="color: rgb(211, 84, 0);"><em>25 quy tắc giao dịch cá nhân</em></strong>&nbsp;đã giúp Brent Donnelly tồn tại gần 30 năm trong ngành cũng được ông chia sẻ trong sách.</p><p>Tham khảo chi tiết tại:&nbsp;<a href="https://finfin.vn/products/kham-pha-nghe-thuat-giao-dich-tien-te-chuyen-nghiep" rel="noopener noreferrer" target="_blank" style="background-color: transparent; color: rgb(204, 0, 153);">https://finfin.vn/products/kham-pha-nghe-thuat-giao-dich-tien-te-chuyen-nghiep</a></p><p>&nbsp;</p><p><strong style="color: rgb(0, 153, 204);">Đánh Bại Thị Trường Forex</strong></p><p>Từng làm việc trên cả thị trường liên ngân hàng (interbank) lẫn thị trường nhỏ lẻ (retail sector), tác giả Agustin Silvani đề cập nhiều vấn đề tổng quát và quan trọng như:</p><ul><li>Cấu trúc vận hành thị trường forex.</li><li>Nhận diện và đối phó các chiêu trò của dealer, hiểu nôm na là môi giới kiêm lái giá.</li><li>Những kinh nghiệm giúp trở thành trader Top 10%.</li><li>Các mẹo hay để giao dịch tốt hơn.</li><li>Kỹ thuật giao dịch chống lại hành vi thao túng giá.</li><li>Tham khảo chi tiết tại:&nbsp;<a href="https://finfin.vn/products/danh-bai-thi-truong-forex" rel="noopener noreferrer" target="_blank" style="background-color: transparent; color: rgb(204, 0, 153);">https://finfin.vn/products/danh-bai-thi-truong-forex</a></li></ul><p>&nbsp;</p><p><strong style="color: rgb(0, 153, 204);">Thực hành Phân tích Fibonacci</strong></p><p>Một quyển sách không thể&nbsp;bỏ qua được viết bởi bà&nbsp;Constance Brown - một tác giả giỏi&nbsp;thật sự ở mặt thực chiến lẫn học thuật.&nbsp;</p><ul><li>Sách nằm trong Top các quyển sách hay nhất về chủ đề Fibonacci trên Amazon.</li><li>Sách đã đoạt Huy chương vàng trong hạng mục Axiom Business Book Awards năm 2009.</li><li>Sách được Bloomberg Press thuộc hãng tin Bloomberg xuất bản và chọn vào chuỗi sách Bloomberg Market Essentials: Technical Analysis (tạm dịch Các yếu tố cần thiết cho thị trường của Bloomberg: Phân tích Kỹ thuật).</li></ul><p>Tựa sách cung cấp cho độc giả những kiến thức mà chúng ta có thể áp dụng ngay lập tức bao gồm:</p><ul><li>GIỚI THIỆU cách dùng tỷ lệ Fibonacci để dự báo mục tiêu giá.</li><li>CUNG CẤP các ví dụ chi tiết và các bối cảnh thực, trên thị trường thực.&nbsp;</li><li>GIẢI THÍCH về tầm quan trọng của tỉ lệ thức khi phân tích biểu đồ.</li><li>CẢNH BÁO các nhà giao dịch về những lỗi lầm thường gặp.</li><li>MÔ TẢ cách xác định những tín hiệu sai.</li></ul><p><br></p><p>Kỹ thuật giao dịch được đề cập trong sách là sự kết hợp giữa phân tích hành vi giá - price action - trong tổng thể phối hợp với các tỷ lệ Fibonacci nhằm giúp trader đưa ra kế hoạch giao dịch hiệu quả, rủi ro thấp.</p><p><br></p><p>Tham khảo chi tiết tại:&nbsp;&nbsp;<a href="https://finfin.vn/products/danh-bai-thi-truong-forex" rel="noopener noreferrer" target="_blank" style="background-color: transparent; color: rgb(204, 0, 153);">https://finfin.vn/products/thuc-hanh-phan-tich-fibonacci</a></p>'
const countUp = () => {
  quantity.value += 1
}
const countDown = () => {
  if (quantity.value > 1) {
    quantity.value -= 1
  }
}
const slides = [
  {
    imageUrl:
      'https://lh3.googleusercontent.com/proxy/l9UjrdGdFmVSzX2edJZ13EWA7ibWUTP030BM2PcbjUI3Wt5jQURk5i3d8As67OFTqBG7cpOupiAVzT_Dz_9HrB4ffqLVVHYN_paXuIreIWveSiUQZIetZsZ399y6zXGe2oqIz4o8eloGonmz43TAS7rzywY1DpcUW3cdE-aEmBaQTqQVcIeT9IJ4XsAK6M3AaRg',
    link: ''
  },
  {
    imageUrl:
      'https://isachhay.net/wp-content/uploads/2017/08/sach-hay-tuoi-tre-dang-gia-bao-nhieu.jpg',
    link: ''
  },
  {
    imageUrl: 'https://www.elle.vn/wp-content/uploads/2020/07/01/406325/sach-hay-ve-tuoi-tre.jpg',
    link: ''
  },
  {
    imageUrl: 'https://hoachio.com/wp-content/uploads/2021/06/2ban-dat-gia-bao-nhieu.jpg',
    link: ''
  }
]
const heightSlide = '460px'
const title = 'Bộ sách "Kỹ năng và Phương pháp Giao dịch của các Trader Quản lý Quỹ"'
</script>
<template>
  <div class="detail_product">
    <breadCrumb :nameBreadCrumb="title" />
    <div class="main_detail_product">
      <div class="container_product_gallary">
        <div class="product_gallary">
          <!-- // CptQuill test for main_info_product -->
          <!-- <CptQuill @changeContentCode="changeContentCode" /> -->

          <div class="slide_book_show">
            <CptSlideShow :arrayImage="slides" :height-slide="heightSlide" />
          </div>
          <div class="sub_title">
            <h4>Hình ảnh của sách</h4>
            <div class="line"></div>
          </div>
        </div>
      </div>
      <div class="info_detail_product">
        <div class="title_book">
          <h1>{{ title }}</h1>
          <div class="note_title_book"><span>SKU: 120053</span></div>
        </div>
        <div class="product_price"><span>347,000₫</span></div>
        <div class="quantity_book"><span>Số lượng:</span></div>
        <div class="select_number_book">
          <div @click="countDown" class="count_down">-</div>
          <div class="quantity">{{ quantity }}</div>
          <div @click="countUp" class="count_up">+</div>
        </div>
        <div class="add_to_cart">
          <button>THÊM VÀO GIỎ</button>
        </div>
        <div class="free_ship_info">Miễn phí giao hàng toàn quốc cho đơn hàng từ 295.000đ</div>
        <div class="des_detail">Mô tả</div>
        <div v-html="contentCodeDemo" class="main_info_product"></div>
      </div>
    </div>
  </div>
</template>
<style lang="scss">
@import '@/common/mixin/mixinButton.scss';
.detail_product {
  .main_detail_product {
    padding-top: 40px;
    // height: 3000px;
    padding-bottom: 200px;
    display: flex;
    .container_product_gallary {
      position: relative;
      padding: 0px 15px;
      width: 40%;
      .product_gallary {
        width: 100%;
        position: -webkit-sticky;
        position: sticky;
        float: left;
        top: 0px;

        .slide_book_show {
          width: 100%;
          border: 1px solid #e0e0e0;
          .vueperslide {
            background-size: contain;
            background-repeat: no-repeat;
          }
        }
        .sub_title {
          display: flex;
          flex-direction: column;
          justify-content: center;
          h4 {
            display: block;
            text-align: center;
            font-size: 24px;
            color: $color_default_for_text;
            margin-top: 10px;
            font-weight: 400;
            padding-bottom: 20px;
          }
          .line {
            display: block;
            width: 20%;
            height: 5px;
            background-color: $color_default_for_text;
            border-radius: 10px;
            margin-left: 70px;
            text-align: center;
          }
        }
      }
    }

    // config css for text of info detail product
    .info_detail_product {
      width: 60%;
      .title_book {
        padding-bottom: 10px;
        border-bottom: 1px dotted $color_line_border;
        h1 {
          font-size: 24px;
          color: $color_default_for_text;
          font-weight: 500;
          margin-bottom: 5px;
        }
        .note_title_book {
          span {
            font-size: 12px;
            color: #a3a5a7;
            font-weight: 300;
          }
        }
      }

      .product_price {
        font-size: 18px;
        color: $color_default_for_text;
        font-weight: 600;
        padding: 10px 0px;
        border-bottom: 1px dotted $color_line_border;
      }

      .quantity_book {
        font-size: 14px;
        color: $color_default_for_text;
        font-weight: 300;
        padding: 10px 0px;
      }

      .select_number_book {
        display: flex;
        justify-content: start;
        margin-bottom: 15px;
        .count_down,
        .count_up,
        .quantity {
          font-size: 18px;
          color: $color_default_for_text;
          font-weight: 700;
          text-align: center;
          border: solid 1px #f5f5f5;
          display: flex;
          align-items: center;
          justify-content: center;
        }
        .quantity {
          padding-left: 30px;
          padding-right: 30px;
        }
        .count_down,
        .count_up {
          height: 40px;
          width: 40px;
          user-select: none;
          cursor: pointer;
          background-color: #f5f5f5;

          &:hover {
            background-color: #ebebeb;
          }
          &:active {
            background-color: #e5e5e5;
          }
        }
      }
      .add_to_cart {
        margin-top: 20px;
        button {
          @include btn-border-drawing;
          width: 25%;
          height: 50px;
          background-color: $color_button;
          color: white;
          font-size: 18px;
          font-weight: 500;
          border: none;
          border-radius: 5px;
          cursor: pointer;
          &:hover {
            background-color: $color_button_hover;
          }
          &:active {
            background-color: $color_default_for_hover_text;
          }
        }
      }
      .free_ship_info {
        font-size: 14px;
        color: red;
        font-weight: 600;
        margin-top: 20px;
        margin-bottom: 10px;
        padding-bottom: 2px;
        border-bottom: 1px dotted $color_line_border;
      }
      .des_detail {
        font-size: 14px;
        color: $color_default_for_text;
        font-weight: 500;
        margin-bottom: 13px;
      }
      padding: 0px 15px;
      .main_info_product {
        ul {
          margin: 0px 0px 10px 30px;
        }
        p {
          margin-bottom: 10px;
          font-size: 18px;
          color: $color_default_for_text;
          font-weight: 300;
          line-height: 1.2;
        }
        .ql-align-center {
          text-align: center;
        }
        li {
          font-weight: 300;
          list-style-type: disc;
          padding: 1px 0px;
          line-height: 1.2;
        }
        img {
          max-width: 100%;
        }
        h2 {
          font-weight: 500;
          margin-bottom: 13px;
        }
      }
    }
  }
}

// css button for slide image
.vueperslides__arrow {
  padding: 0px 12px;
  color: $color_default_for_text;
  border-radius: 50%;
  background-color: hsla(0, 0%, 100%, 0.75);
}
</style>
