using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KarnelTravelAPI.Migrations
{
    public partial class KarnelTravel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Location_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Location_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status_Location = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Location_id);
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    Tour_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tour_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status_tour = table.Column<bool>(type: "bit", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: true),
                    Depature_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Times = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.Tour_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total_payment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Charge_card = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status_User = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_id);
                });

            migrationBuilder.CreateTable(
                name: "Accommodations",
                columns: table => new
                {
                    Accommodation_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Accommodation_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status_Accommodation = table.Column<bool>(type: "bit", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: true),
                    Location_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accommodations", x => x.Accommodation_id);
                    table.ForeignKey(
                        name: "FK_Accommodations_Locations_Location_id",
                        column: x => x.Location_id,
                        principalTable: "Locations",
                        principalColumn: "Location_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationImages",
                columns: table => new
                {
                    Location_img_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    photo_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationImages", x => x.Location_img_id);
                    table.ForeignKey(
                        name: "FK_LocationImages_Locations_Location_id",
                        column: x => x.Location_id,
                        principalTable: "Locations",
                        principalColumn: "Location_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Restaurant_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Restaurant_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status_Restaurant = table.Column<bool>(type: "bit", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: true),
                    Location_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Restaurant_id);
                    table.ForeignKey(
                        name: "FK_Restaurants_Locations_Location_id",
                        column: x => x.Location_id,
                        principalTable: "Locations",
                        principalColumn: "Location_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TouristSpots",
                columns: table => new
                {
                    TouristSpot_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TouristSpot_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Activities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status_TouristSpot = table.Column<bool>(type: "bit", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: true),
                    Location_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristSpots", x => x.TouristSpot_id);
                    table.ForeignKey(
                        name: "FK_TouristSpots_Locations_Location_id",
                        column: x => x.Location_id,
                        principalTable: "Locations",
                        principalColumn: "Location_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transports",
                columns: table => new
                {
                    Transport_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Start_position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transport_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status_Transport = table.Column<bool>(type: "bit", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: true),
                    Location_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transports", x => x.Transport_id);
                    table.ForeignKey(
                        name: "FK_Transports_Locations_Location_id",
                        column: x => x.Location_id,
                        principalTable: "Locations",
                        principalColumn: "Location_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccommodationImages",
                columns: table => new
                {
                    Accommodation_img_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    photo_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accommodation_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccommodationImages", x => x.Accommodation_img_id);
                    table.ForeignKey(
                        name: "FK_AccommodationImages_Accommodations_Accommodation_id",
                        column: x => x.Accommodation_id,
                        principalTable: "Accommodations",
                        principalColumn: "Accommodation_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccommodationTours",
                columns: table => new
                {
                    Tour_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Accommodation_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccommodationTours", x => new { x.Accommodation_id, x.Tour_id });
                    table.ForeignKey(
                        name: "FK_AccommodationTours_Accommodations_Accommodation_id",
                        column: x => x.Accommodation_id,
                        principalTable: "Accommodations",
                        principalColumn: "Accommodation_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccommodationTours_Tours_Tour_id",
                        column: x => x.Tour_id,
                        principalTable: "Tours",
                        principalColumn: "Tour_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantImages",
                columns: table => new
                {
                    Restaurant_img_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    photo_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Restaurant_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantImages", x => x.Restaurant_img_id);
                    table.ForeignKey(
                        name: "FK_RestaurantImages_Restaurants_Restaurant_id",
                        column: x => x.Restaurant_id,
                        principalTable: "Restaurants",
                        principalColumn: "Restaurant_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantTours",
                columns: table => new
                {
                    Tour_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Restaurant_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantTours", x => new { x.Restaurant_id, x.Tour_id });
                    table.ForeignKey(
                        name: "FK_RestaurantTours_Restaurants_Restaurant_id",
                        column: x => x.Restaurant_id,
                        principalTable: "Restaurants",
                        principalColumn: "Restaurant_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantTours_Tours_Tour_id",
                        column: x => x.Tour_id,
                        principalTable: "Tours",
                        principalColumn: "Tour_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TouristSpotImages",
                columns: table => new
                {
                    TouristSpot_img_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    photo_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TouristSpot_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristSpotImages", x => x.TouristSpot_img_id);
                    table.ForeignKey(
                        name: "FK_TouristSpotImages_TouristSpots_TouristSpot_id",
                        column: x => x.TouristSpot_id,
                        principalTable: "TouristSpots",
                        principalColumn: "TouristSpot_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TouristSpotTours",
                columns: table => new
                {
                    Tour_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TouristSpot_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristSpotTours", x => new { x.TouristSpot_id, x.Tour_id });
                    table.ForeignKey(
                        name: "FK_TouristSpotTours_TouristSpots_TouristSpot_id",
                        column: x => x.TouristSpot_id,
                        principalTable: "TouristSpots",
                        principalColumn: "TouristSpot_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TouristSpotTours_Tours_Tour_id",
                        column: x => x.Tour_id,
                        principalTable: "Tours",
                        principalColumn: "Tour_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    booking_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    User_id = table.Column<int>(type: "int", nullable: false),
                    Tour_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Accommodation_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Restaurant_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TouristSpot_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Transport_id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.booking_id);
                    table.ForeignKey(
                        name: "FK_Bookings_Accommodations_Accommodation_id",
                        column: x => x.Accommodation_id,
                        principalTable: "Accommodations",
                        principalColumn: "Accommodation_id");
                    table.ForeignKey(
                        name: "FK_Bookings_Restaurants_Restaurant_id",
                        column: x => x.Restaurant_id,
                        principalTable: "Restaurants",
                        principalColumn: "Restaurant_id");
                    table.ForeignKey(
                        name: "FK_Bookings_TouristSpots_TouristSpot_id",
                        column: x => x.TouristSpot_id,
                        principalTable: "TouristSpots",
                        principalColumn: "TouristSpot_id");
                    table.ForeignKey(
                        name: "FK_Bookings_Tours_Tour_id",
                        column: x => x.Tour_id,
                        principalTable: "Tours",
                        principalColumn: "Tour_id");
                    table.ForeignKey(
                        name: "FK_Bookings_Transports_Transport_id",
                        column: x => x.Transport_id,
                        principalTable: "Transports",
                        principalColumn: "Transport_id");
                    table.ForeignKey(
                        name: "FK_Bookings_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransportTours",
                columns: table => new
                {
                    Tour_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Transport_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportTours", x => new { x.Transport_id, x.Tour_id });
                    table.ForeignKey(
                        name: "FK_TransportTours_Tours_Tour_id",
                        column: x => x.Tour_id,
                        principalTable: "Tours",
                        principalColumn: "Tour_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransportTours_Transports_Transport_id",
                        column: x => x.Transport_id,
                        principalTable: "Transports",
                        principalColumn: "Transport_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Feedback_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    Status_Feedback = table.Column<bool>(type: "bit", nullable: false),
                    booking_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Feedback_id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Bookings_booking_id",
                        column: x => x.booking_id,
                        principalTable: "Bookings",
                        principalColumn: "booking_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Payment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status_payment = table.Column<bool>(type: "bit", nullable: false),
                    Booking_id = table.Column<int>(type: "int", nullable: false),
                    UserModelUser_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Payment_id);
                    table.ForeignKey(
                        name: "FK_Payments_Bookings_Booking_id",
                        column: x => x.Booking_id,
                        principalTable: "Bookings",
                        principalColumn: "booking_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Users_UserModelUser_id",
                        column: x => x.UserModelUser_id,
                        principalTable: "Users",
                        principalColumn: "User_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccommodationImages_Accommodation_id",
                table: "AccommodationImages",
                column: "Accommodation_id");

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_Location_id",
                table: "Accommodations",
                column: "Location_id");

            migrationBuilder.CreateIndex(
                name: "IX_AccommodationTours_Tour_id",
                table: "AccommodationTours",
                column: "Tour_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Accommodation_id",
                table: "Bookings",
                column: "Accommodation_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Restaurant_id",
                table: "Bookings",
                column: "Restaurant_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Tour_id",
                table: "Bookings",
                column: "Tour_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TouristSpot_id",
                table: "Bookings",
                column: "TouristSpot_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Transport_id",
                table: "Bookings",
                column: "Transport_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_User_id",
                table: "Bookings",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_booking_id",
                table: "Feedbacks",
                column: "booking_id");

            migrationBuilder.CreateIndex(
                name: "IX_LocationImages_Location_id",
                table: "LocationImages",
                column: "Location_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Booking_id",
                table: "Payments",
                column: "Booking_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserModelUser_id",
                table: "Payments",
                column: "UserModelUser_id");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantImages_Restaurant_id",
                table: "RestaurantImages",
                column: "Restaurant_id");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_Location_id",
                table: "Restaurants",
                column: "Location_id");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantTours_Tour_id",
                table: "RestaurantTours",
                column: "Tour_id");

            migrationBuilder.CreateIndex(
                name: "IX_TouristSpotImages_TouristSpot_id",
                table: "TouristSpotImages",
                column: "TouristSpot_id");

            migrationBuilder.CreateIndex(
                name: "IX_TouristSpots_Location_id",
                table: "TouristSpots",
                column: "Location_id");

            migrationBuilder.CreateIndex(
                name: "IX_TouristSpotTours_Tour_id",
                table: "TouristSpotTours",
                column: "Tour_id");

            migrationBuilder.CreateIndex(
                name: "IX_Transports_Location_id",
                table: "Transports",
                column: "Location_id");

            migrationBuilder.CreateIndex(
                name: "IX_TransportTours_Tour_id",
                table: "TransportTours",
                column: "Tour_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccommodationImages");

            migrationBuilder.DropTable(
                name: "AccommodationTours");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "LocationImages");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "RestaurantImages");

            migrationBuilder.DropTable(
                name: "RestaurantTours");

            migrationBuilder.DropTable(
                name: "TouristSpotImages");

            migrationBuilder.DropTable(
                name: "TouristSpotTours");

            migrationBuilder.DropTable(
                name: "TransportTours");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Accommodations");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "TouristSpots");

            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "Transports");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
