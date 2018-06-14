cmake_minimum_required(VERSION 3.5)
project(demo_opengl)

set(CMAKE_CXX_STANDARD 14)

add_executable(demo_opengl main.cpp shader_s.h headers.h camera.h)
SET_TARGET_PROPERTIES(demo_opengl
        PROPERTIES
        ARCHIVE_OUTPUT_DIRECTORY "${CMAKE_SOURCE_DIR}/bin"
        LIBRARY_OUTPUT_DIRECTORY "${CMAKE_SOURCE_DIR}/bin"
        RUNTIME_OUTPUT_DIRECTORY "${CMAKE_SOURCE_DIR}/bin"
        )
target_include_directories(demo_opengl PRIVATE "${CMAKE_SOURCE_DIR}/glm-0.9.8.5")


set(EMCC_LINKER_FLAGS "--emrun -O2 -s WASM=1 \
                           --preload-file ../shader.vs@/shader.vs \
                           --preload-file ../shader.fs@/shader.fs \
                           -s USE_WEBGL2=1 -s USE_GLFW=3\
                           -s NO_EXIT_RUNTIME=0 -s ASSERTIONS=1")
SET(CMAKE_EXE_LINKER_FLAGS ${EMCC_LINKER_FLAGS})
SET(CMAKE_EXECUTABLE_SUFFIX ".html")