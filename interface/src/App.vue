<template>
  <div id="app">
    <!-- Navbar -->
    <nav class="navbar" :class="{ hidden: isNavbarHidden }" ref="navbar">
      <div class="logo animated-logo">
  <img src="D:\DATN\TutaiSpaa\interface\src\assets\img\logo.png" alt="TutaSpa Logo" class="logo-image" />
</div>

      <ul class="nav-links">
        <li><a href="#"><i class="fa-solid fa-house"></i> Trang Chủ</a></li>
        <li><a href="#"><i class="fa-solid fa-briefcase"></i> Dịch Vụ</a></li>
        <li><a href="#"><i class="fa-regular fa-calendar-check"></i> Đặt Lịch</a></li>
        <li><a href="#"><i class="fa-solid fa-circle-info"></i> Giới Thiệu</a></li>
        <li><a href="#"><i class="fa-solid fa-envelope"></i> Liên Hệ</a></li>
      </ul>
      <div class="user-icon">
        <i class="fa-solid fa-circle-user"></i>
        <i class="fa-regular fa-calendar-check"></i>
      </div>
    </nav>

    <main class="main-content">
      <!-- Carousel -->
      <div id="bannerCarousel" class="carousel slide my-4 container rounded overflow-hidden" data-bs-ride="carousel">
        <div class="carousel-inner rounded-4 shadow">
          <div class="carousel-item active">
            <img src="D:\DATN\TutaiSpaa\interface\src\assets\img\h6.jpg" class="d-block w-100" alt="Banner 1" />
          </div>
          <div class="carousel-item">
            <img src="D:\DATN\TutaiSpaa\interface\src\assets\img\h1.jpg" class="d-block w-100" alt="Banner 2" />
          </div>
          <div class="carousel-item">
            <img src="D:\DATN\TutaiSpaa\interface\src\assets\img\h2.jpg" class="d-block w-100" alt="Banner 3" />
          </div>
          <div class="carousel-item">
            <img src="D:\DATN\TutaiSpaa\interface\src\assets\img\h5.jpg" class="d-block w-100" alt="Banner 4" />
          </div>
        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#bannerCarousel" data-bs-slide="prev">
          <span class="carousel-control-prev-icon" aria-hidden="true"></span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#bannerCarousel" data-bs-slide="next">
          <span class="carousel-control-next-icon" aria-hidden="true"></span>
        </button>
        <div class="carousel-indicators">
          <button type="button" data-bs-target="#bannerCarousel" data-bs-slide-to="0" class="active"></button>
          <button type="button" data-bs-target="#bannerCarousel" data-bs-slide-to="1"></button>
          <button type="button" data-bs-target="#bannerCarousel" data-bs-slide-to="2"></button>
          <button type="button" data-bs-target="#bannerCarousel" data-bs-slide-to="3"></button>
        </div>
      </div>

      <!-- Đặt lịch + Đánh giá -->
<div class="container my-5">
  <div class="row g-4 align-items-stretch">
    <!-- Form Đặt Lịch -->
    <div class="col-md-8">
      <div class="card text-white rounded-4 shadow h-100" style="background: linear-gradient(135deg, #ec407a, #f8bbd0 );">
        <div class="card-body">
          <h5 class="fw-bold mb-2">ĐẶT LỊCH GIỮ CHỖ CHỈ 30 GIÂY</h5>
          <p class="text-white-50 mb-4">Trải nghiệm xong trả tiền, huỷ lịch không sao</p>

          <form class="d-flex flex-column flex-sm-row gap-3">
            <input type="tel" class="form-control form-control-lg rounded-pill px-4" placeholder="Nhập SĐT để đặt lịch" aria-label="SĐT">
            <button class="btn btn-warning text-white fw-bold rounded-pill px-4 py-2" style="background: linear-gradient(135deg, #003580, #00b4db);" type="submit" >
              ĐẶT LỊCH NGAY
            </button>
          </form>
        </div>
      </div>
    </div>

    <!-- Khung Đánh Giá -->
    <div class="col-md-4">
      <div class="card shadow-sm border-0 rounded-4 h-100">
        <div class="card-body">
          <h6 class="text-uppercase fw-bold text-primary mb-2">
            MỜI ANH CHỊ ĐÁNH GIÁ CHẤT LƯỢNG PHỤC VỤ
          </h6>
          <p class="text-secondary small mb-4">
            Phản hồi của anh sẽ giúp chúng em cải thiện chất lượng dịch vụ tốt hơn
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




      <!-- Router View -->
      <router-view />
    </main>
  </div>

  <!-- Floating Button -->
<div class="floating-menu">
  <!-- Nút chính -->
  <button class="main-btn" @click="toggleMenu">
    <i class="fa-solid fa-phone"></i>
  </button>

  <!-- Menu các chức năng -->
  <div class="menu-items" :class="{ 'show-menu': isMenuVisible }" id="menuItems">
    <div class="menu-item">
      <a href="https://zalo.me" target="_blank">
        <i class="fa-brands fa-zalo"></i>
        <span>Chat trên Zalo</span>
      </a>
    </div>
    <div class="menu-item">
      <a href="https://m.me/" target="_blank">
        <i class="fa-brands fa-facebook-messenger"></i>
        <span>Chat trên Facebook</span>
      </a>
    </div>
    <div class="menu-item">
      <a href="tel:0123456789">
        <i class="fa-solid fa-phone"></i>
        <span>Gọi hotline</span>
      </a>
    </div>
    <div class="menu-item">
      <a href="#">
        <i class="fa-regular fa-star"></i>
        <span>Đánh giá dịch vụ</span>
      </a>
    </div>
    <div class="menu-item">
      <a href="#">
        <i class="fa-solid fa-house"></i>
        <span>Liên hệ nhượng quyền</span>
      </a>
    </div>
    <!-- Nút đóng -->
    <button class="close-btn" @click="toggleMenu">
      <i class="fa-solid fa-xmark"></i>
    </button>
  </div>
</div>

</template>

<script setup>
import { onMounted, ref } from 'vue'

const isNavbarHidden = ref(false)
let lastScroll = 0

onMounted(() => {
  window.addEventListener('scroll', () => {
    const currentScroll = window.pageYOffset || document.documentElement.scrollTop
    if (currentScroll > lastScroll && currentScroll > 100) {
      isNavbarHidden.value = true
    } else {
      isNavbarHidden.value = false
    }
    lastScroll = currentScroll
  })
})
const isMenuVisible = ref(false)

function toggleMenu() {
  isMenuVisible.value = !isMenuVisible.value
}

</script>

<style scoped>
body {
  margin: 0;
  font-family: "Segoe UI", Tahoma, Geneva, Verdana, sans-serif;
  background: #fff;
}

/* Navbar */
.navbar {
  background-color: #fff;
  color: #f7c213;
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 13px 23px;
  position: sticky;
  top: 0;
  z-index: 1000;
  transition: transform 0.4s ease;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.05);
}
.navbar.hidden {
  transform: translateY(-100%);
}
.nav-links {
  list-style: none;
  display: flex;
  gap: 50px;
  margin: 0;
  padding: 0;
  font-size: 21px;
}
.nav-links li a {
  position: relative;
  color: #8e0d3c; /* Màu mặc định */
  text-decoration: none;
  transition: color 0.3s;
  font-size: 21px;
}

/* Gạch dưới ẩn ban đầu */
.nav-links li a::after {
  content: "";
  position: absolute;
  bottom: -4px;
  left: 0;
  width: 0%;
  height: 2px;
  background-color: #8e0d3c; /* Màu gạch dưới */
  transition: width 0.3s ease;
}

/* Khi hover: đổi màu và hiện gạch dưới */
.nav-links li a:hover {
  color: #a70043;
}

.nav-links li a:hover::after {
  width: 100%;
}

.nav-links i {
  margin-right: 6px;
}
.user-icon i {
  font-size: 24px;
  color: #8e0d3c; /* màu mận đỏ như ảnh */;
  margin-left: 10px;
  cursor: pointer;
  transition: transform 0.3s ease;
}
.user-icon i:hover {
  transform: scale(1.1);
}

/* Logo Animation */
.logo-image {
  height: 75px; /* hoặc kích thước bạn muốn */
  animation: fadeInDown 1s ease-in-out;
}

/* Nếu bạn có hiệu ứng logo đang dùng */
@keyframes fadeInDown {
  from {
    opacity: 0;
    transform: translateY(-20px);
  }
  to {
    opacity: 1;
    transform: translateY(0);
  }
}


/* Content */
.main-content {
  padding: 20px;
}
.carousel-inner img {
  object-fit: cover;
  height: 400px;
}

.input-group-custom {
  display: flex;
  flex-wrap: nowrap;
  gap: 12px;
  width: 100%;
  max-width: 600px;
  margin: auto;
}

.input-custom {
  flex: 1;
  padding: 14px 16px;
  border-radius: 12px;
  border: 1px solid #ccc;
  transition: all 0.3s ease;
  font-size: 16px;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.05);
}

.input-custom:focus {
  border-color: #2a5298;
  box-shadow: 0 0 0 4px rgba(42, 82, 152, 0.2);
  outline: none;
}

.btn-submit {
  padding: 12px 24px;
  border: none;
  border-radius: 12px;
  background: linear-gradient(135deg, #1e3c72, #2a5298);
  color: white;
  font-weight: bold;
  font-size: 16px;
  white-space: nowrap;
  transition: transform 0.3s ease, box-shadow 0.3s ease;
  box-shadow: 0 4px 14px rgba(42, 82, 152, 0.4);
}

.btn-submit:hover {
  transform: translateY(-2px);
  box-shadow: 0 6px 16px rgba(42, 82, 152, 0.6);
}

@media (max-width: 576px) {
  .input-group-custom {
    flex-direction: column;
    gap: 8px;
  }

  .btn-submit {
    width: 100%;
  }
}

.form-control-custom {
  flex: 1;
  padding: 12px 16px;
  border: none;
  border-radius: 8px 0 0 8px;
  outline: none;
  font-size: 16px;
}
.btn-custom {
  padding: 12px 20px;
  background-color: #fff;
  color: #000;
  font-weight: bold;
  border: none;
  border-radius: 0 8px 8px 0;
  cursor: pointer;
  transition: background-color 0.3s ease;
}
.btn-custom:hover {
  background-color:#f1f1f1;
}

/* Responsive input group */
@media (max-width: 768px) {
  .input-group-custom {
    flex-direction: column;
  }
  .form-control-custom {
    border-radius: 8px 8px 0 0;
  }
  .btn-custom {
    border-radius: 0 0 8px 8px;
  }
}

/* ⭐ Hiệu ứng sao động */
.custom-star {
  font-size: 36px; /* giống ảnh */
  color: white;
  transition: color 0.6s ease;
}

.star-yellow {
  color: #ffd700; /* vàng gold */
}


.animated-stars .star-animate {
  color: white;
  animation: glowStar 1.5s ease-in-out infinite;
}
.animated-stars .delay-1 {
  animation-delay: 0.2s;
}
.animated-stars .delay-2 {
  animation-delay: 0.4s;
}
.animated-stars .delay-3 {
  animation-delay: 0.6s;
}
.animated-stars .delay-4 {
  animation-delay: 0.8s;
}

@keyframes glowStar {
  0% {
    color: white;
    transform: scale(1);
  }
  50% {
    color: #ffd700; 
    transform: scale(1.1);
  }
  100% {
    color: white;
    transform: scale(1);
  }
}
/* phần thêm bên phải */
.floating-menu {
  position: fixed;
  bottom: 20px;
  right: 20px;
  z-index: 1001;
}

.main-btn, .close-btn {
  width: 60px;
  height: 60px;
  background: linear-gradient(135deg, #0d47a1, #1976d2);
  border: none;
  border-radius: 50%;
  color: white;
  font-size: 24px;
  box-shadow: 0 4px 12px rgba(0,0,0,0.2);
  cursor: pointer;
  transition: transform 0.3s ease;
}

.main-btn:hover, .close-btn:hover {
  transform: scale(1.05);
}

.menu-items {
  display: none;
  flex-direction: column;
  align-items: flex-end;
  margin-bottom: 10px;
}

.menu-item {
  background: #fff;
  color: #333;
  border-radius: 30px;
  padding: 8px 12px;
  margin-bottom: 10px;
  box-shadow: 0 2px 6px rgba(0,0,0,0.15);
  display: flex;
  align-items: center;
  gap: 10px;
  transition: all 0.3s ease;
}

.menu-item i {
  color: #0d47a1;
  font-size: 20px;
}

.menu-item span {
  white-space: nowrap;
  font-size: 14px;
}

.menu-item:hover {
  background: #f5f5f5;
}

.show-menu {
  display: flex !important;
}


</style>

