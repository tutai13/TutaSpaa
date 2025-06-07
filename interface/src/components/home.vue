<template>
  <!-- Carousel -->
  <div
    id="bannerCarousel"
    class="carousel slide my-4 container rounded overflow-hidden"
    data-bs-ride="carousel"
  >
    <div class="carousel-inner rounded-4 shadow">
      <div class="carousel-item active">
        <img
          src="\src\assets\img\h6.jpg"
          class="d-block w-100"
          alt="Banner 1"
        />
      </div>
      <div class="carousel-item">
        <img
          src="\src\assets\img\h1.jpg"
          class="d-block w-100"
          alt="Banner 2"
        />
      </div>
      <div class="carousel-item">
        <img
          src="\src\assets\img\h2.jpg"
          class="d-block w-100"
          alt="Banner 3"
        />
      </div>
      <div class="carousel-item">
        <img
          src="\src\assets\img\h5.jpg"
          class="d-block w-100"
          alt="Banner 4"
        />
      </div>
    </div>
    <button
      class="carousel-control-prev"
      type="button"
      data-bs-target="#bannerCarousel"
      data-bs-slide="prev"
    >
      <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    </button>
    <button
      class="carousel-control-next"
      type="button"
      data-bs-target="#bannerCarousel"
      data-bs-slide="next"
    >
      <span class="carousel-control-next-icon" aria-hidden="true"></span>
    </button>
    <div class="carousel-indicators">
      <button
        type="button"
        data-bs-target="#bannerCarousel"
        data-bs-slide-to="0"
        class="active"
      ></button>
      <button
        type="button"
        data-bs-target="#bannerCarousel"
        data-bs-slide-to="1"
      ></button>
      <button
        type="button"
        data-bs-target="#bannerCarousel"
        data-bs-slide-to="2"
      ></button>
      <button
        type="button"
        data-bs-target="#bannerCarousel"
        data-bs-slide-to="3"
      ></button>
    </div>
  </div>

  <!-- Đặt lịch + Đánh giá -->
  <div class="container my-5">
    <div class="row g-4 align-items-stretch">
      <!-- Form Đặt Lịch -->
      <div class="col-md-8">
        <div
          class="card text-white rounded-4 shadow h-100"
          style="background: linear-gradient(135deg, #ec407a, #f8bbd0)"
        >
          <div class="card-body">
            <h5 class="fw-bold mb-2">ĐẶT LỊCH GIỮ CHỖ CHỈ 30 GIÂY</h5>
            <p class="text-white-50 mb-4">
              Trải nghiệm xong trả tiền, huỷ lịch không sao
            </p>
            <form class="d-flex flex-column flex-sm-row gap-3">
              <input
                type="tel"
                class="form-control form-control-lg rounded-pill px-4"
                placeholder="Nhập SĐT để đặt lịch"
              />
              <button
                class="btn btn-warning text-white fw-bold rounded-pill px-4 py-2"
                style="background: linear-gradient(135deg, #003580, #00b4db)"
                type="submit"
              >
                ĐẶT LỊCH NGAY
              </button>
            </form>
          </div>
        </div>
      </div>

      <!-- Đánh Giá -->
      <div class="col-md-4">
        <div class="card shadow-sm border-0 rounded-4 h-100">
          <div class="card-body">
            <h6 class="text-uppercase fw-bold text-primary mb-2">
              MỜI ANH CHỊ ĐÁNH GIÁ CHẤT LƯỢNG PHỤC VỤ
            </h6>
            <p class="text-secondary small mb-4">
              Phản hồi của anh sẽ giúp chúng em cải thiện chất lượng dịch vụ tốt
              hơn
            </p>
            <div class="fs-4">
              <i class="fa-regular fa-star text-warning me-1"></i>
              <i class="fa-regular fa-star text-warning me-1"></i>
              <i class="fa-regular fa-star text-warning me-1"></i>
              <i class="fa-regular fa-star text-warning me-1"></i>
              <i class="fa-regular fa-star text-warning"></i>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>

  <!-- Hero Section -->
  <section class="home-hero">
    <div class="hero-content">
      <h1>Chào mừng đến với TuTai Spa</h1>
      <p>
        Thư giãn và chăm sóc sắc đẹp với đội ngũ chuyên nghiệp của chúng tôi.
      </p>
      <button @click="goToBooking" class="btn btn-primary">
        Đặt lịch ngay
      </button>
    </div>
  </section>

  <!-- Thanh chọn loại dịch vụ -->
  <div class="container text-center my-4">
    <div class="btn-group flex-wrap" role="group">
      <!-- Nút "Tất cả" -->
      <button
        @click="selectedTypeID = null"
        :class="[
          'btn',
          selectedTypeID === null ? 'btn-primary' : 'btn-outline-primary',
        ]"
      >
        Tất cả
      </button>

      <!-- Các loại dịch vụ -->
      <button
        v-for="type in serviceTypes"
        :key="type.loaiDichVuID"
        @click="selectedTypeID = type.loaiDichVuID"
        :class="[
          'btn',
          selectedTypeID === type.loaiDichVuID
            ? 'btn-primary'
            : 'btn-outline-primary',
        ]"
      >
        {{ type.tenLoai }}
      </button>
    </div>
  </div>

  <!-- Danh sách dịch vụ -->
  <section class="services">
    <h2>Dịch vụ nổi bật</h2>
    <div class="service-list">
      <div
        class="service-item"
        v-for="service in services.filter(
          (s) => selectedTypeID === null || s.loaiDichVuID === selectedTypeID
        )"
        :key="service.id"
      >
        <img :src="service.image" :alt="service.name" />
        <h3>{{ service.name }}</h3>
        <p>{{ service.description }}</p>
      </div>
    </div>
  </section>

  <!-- About -->
  <section class="about">
    <h2>Về TuTai Spa</h2>
    <p>
      TuTai Spa cam kết mang đến cho bạn trải nghiệm thư giãn và làm đẹp tốt
      nhất với công nghệ hiện đại và nhân viên tận tâm.
    </p>
  </section>
</template>

<script setup>
import { onMounted, ref } from "vue";
import axios from "axios";
import { useRouter } from "vue-router";

const router = useRouter();
const services = ref([]);
const serviceTypes = ref([]);
const selectedTypeID = ref(null);

onMounted(async () => {
  try {
    const [dichVuRes, loaiDichVuRes] = await Promise.all([
      axios.get("http://localhost:5233/api/dichvu"),
      axios.get("http://localhost:5233/api/loaidichvu"),
    ]);

    services.value = dichVuRes.data.map((item) => ({
      id: item.dichVuID,
      name: item.tenDichVu,
      description: item.moTa,
      image: item.hinhAnh || "/images/default-service.jpg",
      loaiDichVuID: item.loaiDichVuID,
    }));

    serviceTypes.value = loaiDichVuRes.data;

    if (serviceTypes.value.length > 0) {
      // selectedTypeID.value = serviceTypes.value[0].loaiDichVuID;
      selectedTypeID.value = null; // Mặc định là "Tất cả"
    }
  } catch (error) {
    console.error("Lỗi khi lấy dữ liệu:", error);
  }
});

function goToBooking() {
  router.push("/dat-lich");
}
</script>

<style scoped>
.home-hero {
  background: url("/images/spa-hero.jpg") center center/cover no-repeat;
  color: white;
  text-align: center;
  padding: 120px 20px;
}

.hero-content h1 {
  font-size: 3rem;
  margin-bottom: 1rem;
}

.hero-content p {
  font-size: 1.2rem;
  margin-bottom: 2rem;
}

.services {
  padding: 50px 20px;
  background: #f9f9f9;
  text-align: center;
}

.service-list {
  display: flex;
  justify-content: center;
  gap: 30px;
  flex-wrap: wrap;
}

.service-item {
  background: white;
  border-radius: 10px;
  box-shadow: 0 0 12px rgb(0 0 0 / 0.1);
  max-width: 300px;
  padding: 20px;
}

.service-item img {
  width: 100%;
  border-radius: 8px;
  margin-bottom: 15px;
}

.about {
  padding: 40px 20px;
  max-width: 800px;
  margin: 0 auto;
  font-size: 1.1rem;
  text-align: center;
}
</style>
